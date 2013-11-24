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
using Microsoft.Practices.Unity;
using ps.dmv.common.Core;
using ps.dmv.common.Helpers;
using ps.dmv.common.Security;
using ps.dmv.interfaces.Managers;
using ps.dmv.interfaces.Providers;
using ps.dmv.web.Infrastructure.Core;
using ps.dmv.web.Infrastructure.Security;
using ps.dmv.web.Models;

namespace ps.dmv.web.Controllers
{
    /// <summary>
    /// AccountController
    /// </summary>
    [Authorize]
    public partial class AccountController : BaseDmvController
    {
        private ISecurityManager _securityManager = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="securityManager">The security manager.</param>
        public AccountController(ISecurityManager securityManager)
        {
            _securityManager = securityManager;
        }

        /// <summary>
        /// Gets the _authentication manager.
        /// </summary>
        /// <value>
        /// The _authentication manager.
        /// </value>
        public IAuthenticationManager _authenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        /// <summary>
        /// Logins the specified return URL.
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        [AllowAnonymous]
        public virtual ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        /// <summary>
        /// Logins the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
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
                    await ServiceLocator.Instance.Resolve<IAuthenticationProvider>(new DependencyOverride(typeof(IAuthenticationManager), _authenticationManager)).SignInAsync(user, model.RememberMe);
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

        /// <summary>
        /// Registers this instance.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public virtual ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Registers the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
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
                    await ServiceLocator.Instance.Resolve<IAuthenticationProvider>(new DependencyOverride(typeof(IAuthenticationManager), _authenticationManager)).SignInAsync(user, isPersistent: false);
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

        /// <summary>
        /// Disassociates the specified login provider.
        /// </summary>
        /// <param name="loginProvider">The login provider.</param>
        /// <param name="providerKey">The provider key.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Manages the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Manages the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Externals the login.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action(MVC.Account.ExternalLoginCallback(returnUrl)));
        }

        /// <summary>
        /// Externals the login callback.
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
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
                await ServiceLocator.Instance.Resolve<IAuthenticationProvider>(new DependencyOverride(typeof(IAuthenticationManager), _authenticationManager)).SignInAsync(user, isPersistent: false);
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

        /// <summary>
        /// Links the login.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            return new ChallengeResult(provider, Url.Action(MVC.Account.LinkLoginCallback()), User.Identity.GetUserId());
        }

        /// <summary>
        /// Links the login callback.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Externals the login confirmation.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
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
                        await ServiceLocator.Instance.Resolve<IAuthenticationProvider>(new DependencyOverride(typeof(IAuthenticationManager), _authenticationManager)).SignInAsync(user, isPersistent: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        /// <summary>
        /// Logs the off.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult LogOff()
        {
            ServiceLocator.Instance.Resolve<IAuthenticationProvider>(new DependencyOverride(typeof(IAuthenticationManager), _authenticationManager)).SignOut();

            return RedirectToAction(MVC.Home.Index());
        }

        /// <summary>
        /// Externals the login failure.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public virtual ActionResult ExternalLoginFailure()
        {
            return View();
        }

        /// <summary>
        /// Removes the account list.
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public virtual ActionResult RemoveAccountList()
        {
            IList<UserLoginInfo> linkedAccounts = _securityManager.GetLogins(User.Identity.GetUserId());

            ViewBag.ShowRemoveButton = _securityManager.HasPassword(User.Identity.GetUserId()) || linkedAccounts.Count > 1;

            return (ActionResult)PartialView(MVC.Account.Views._RemoveAccountPartial, linkedAccounts);
        }

        /// <summary>
        /// Releases unmanaged resources and optionally releases managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
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