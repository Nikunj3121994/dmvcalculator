using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using ps.dmv.common.Helpers;
using ps.dmv.common.Security;
using ps.dmv.interfaces.Managers;
using ps.dmv.web.Infrastructure.Core;
using ps.dmv.web.Infrastructure.Security;
using ps.dmv.web.Models;

namespace ps.dmv.web.Controllers
{
    [Authorize]
    public partial class AccountController : BaseDmvController
    {
        private ISecurityManager _securityManager = null;

        public AccountController(ISecurityManager securityManager)
        {
            _securityManager = securityManager;
        }

        public IAuthenticationManager _authenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public virtual ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _securityManager.GetUserAsync(model.UserName, model.Password);

                if (user != null)
                {
                    await new AuthenticationProvider(_authenticationManager, _securityManager).SignInAsync(user, model.RememberMe);
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public virtual ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser() { UserName = model.UserName };
                var result = await _securityManager.CreateRegistrationAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await new AuthenticationProvider(_authenticationManager, _securityManager).SignInAsync(user, isPersistent: false);
                    return RedirectToAction(MVC.Home.Index());
                }
                else
                {
                    AddErrors(result);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/Disassociate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Disassociate(string loginProvider, string providerKey)
        {
            ManageMessageIdEnum? message = null;
            IdentityResult result = await _securityManager.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));

            if (result.Succeeded)
            {
                message = ManageMessageIdEnum.RemoveLoginSuccess;
            }
            else
            {
                message = ManageMessageIdEnum.Error;
            }
            return RedirectToAction(MVC.Account.Manage(message));
        }

        //
        // GET: /Account/Manage
        public virtual ActionResult Manage(ManageMessageIdEnum? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageIdEnum.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageIdEnum.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageIdEnum.RemoveLoginSuccess ? "The external login was removed."
                : message == ManageMessageIdEnum.Error ? "An error has occurred."
                : String.Empty;

            ViewBag.HasLocalPassword = _securityManager.HasPassword(User.Identity.GetUserId());
            ViewBag.ReturnUrl = Url.Action(MVC.Account.Manage());
            return View();
        }

        //
        // POST: /Account/Manage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Manage(ManageUserViewModel model)
        {
            bool hasPassword = _securityManager.HasPassword(User.Identity.GetUserId());
            ViewBag.HasLocalPassword = hasPassword;
            ViewBag.ReturnUrl = Url.Action(MVC.Account.Manage());

            if (hasPassword)
            {
                if (ModelState.IsValid)
                {
                    IdentityResult result = await _securityManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);

                    if (result.Succeeded)
                    {
                        return RedirectToAction(MVC.Account.Manage(ManageMessageIdEnum.ChangePasswordSuccess));
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }
            }
            else
            {
                // User does not have a password so remove any validation errors caused by a missing OldPassword field
                ModelState state = ModelState["OldPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }

                if (ModelState.IsValid)
                {
                    IdentityResult result = await _securityManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(MVC.Account.Manage(ManageMessageIdEnum.SetPasswordSuccess ));
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action(MVC.Account.ExternalLoginCallback(returnUrl)));
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public virtual async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await _authenticationManager.GetExternalLoginInfoAsync();

            if (loginInfo == null)
            {
                return RedirectToAction(MVC.Account.Login());
            }

            // Sign in the user with this external login provider if the user already has a login
            ApplicationUser user = await _securityManager.FindAsync(loginInfo.Login);

            if (user != null)
            {
                await new AuthenticationProvider(_authenticationManager, _securityManager).SignInAsync(user, isPersistent: false);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                // If the user does not have an account, then prompt the user to create an account
                ViewBag.ReturnUrl = returnUrl;
                ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                return View(MVC.Account.Views.ExternalLoginConfirmation, new ExternalLoginConfirmationViewModel { UserName = loginInfo.DefaultUserName });
            }
        }

        //
        // POST: /Account/LinkLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            return new ChallengeResult(provider, Url.Action(MVC.Account.LinkLoginCallback()), User.Identity.GetUserId());
        }

        //
        // GET: /Account/LinkLoginCallback
        public virtual async Task<ActionResult> LinkLoginCallback()
        {
            var loginInfo = await _authenticationManager.GetExternalLoginInfoAsync(DmvConstants.XsrfKey, User.Identity.GetUserId());

            if (loginInfo == null)
            {
                return RedirectToAction(MVC.Account.Manage(ManageMessageIdEnum.Error));
            }

            var result = await _securityManager.AddLoginAsync(User.Identity.GetUserId(), loginInfo.Login);

            if (result.Succeeded)
            {
                return RedirectToAction(MVC.Account.Manage());
            }

            return RedirectToAction(MVC.Account.Manage(ManageMessageIdEnum.Error));
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(MVC.Account.Manage());
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await _authenticationManager.GetExternalLoginInfoAsync();

                if (info == null)
                {
                    return View(MVC.Account.Views.ExternalLoginFailure);
                }

                var user = new ApplicationUser() { UserName = model.UserName };
                var result = await _securityManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    result = await _securityManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await new AuthenticationProvider(_authenticationManager, _securityManager).SignInAsync(user, isPersistent: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult LogOff()
        {
            new AuthenticationProvider(_authenticationManager, _securityManager).SignOut();

            return RedirectToAction(MVC.Home.Index());
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public virtual ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [ChildActionOnly]
        public virtual ActionResult RemoveAccountList()
        {
            IList<UserLoginInfo> linkedAccounts = _securityManager.GetLogins(User.Identity.GetUserId());

            ViewBag.ShowRemoveButton = _securityManager.HasPassword(User.Identity.GetUserId()) || linkedAccounts.Count > 1;

            return (ActionResult)PartialView(MVC.Account.Views._RemoveAccountPartial, linkedAccounts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _securityManager != null)
            {
                _securityManager.Dispose();
                _securityManager = null;
            }

            base.Dispose(disposing);
        }
    }
}