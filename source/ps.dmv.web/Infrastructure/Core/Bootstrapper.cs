using System.Web.Mvc;
using Microsoft.Practices.Unity;
using ps.dmv.common.Core;
using ps.dmv.domain.application.Managers;
using ps.dmv.interfaces.Managers;
using ps.dmv.web.Controllers;

namespace ps.dmv.web.Infrastructure.Core
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            IUnityContainer unityContainer = BuildUnityContainer();

            UnityControllerFactory unityFactory = new UnityControllerFactory(unityContainer);
            ControllerBuilder.Current.SetControllerFactory(unityFactory);

            ServiceLocator.Instance.SetContainer(unityContainer);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            UnityContainer container = new UnityContainer();

            // Controllers
            container.RegisterType<AccountController>();

            container.RegisterType<DmvApiController>();
            container.RegisterType<DmvController>();
            container.RegisterType<ExternalImportCarDataController>();
            container.RegisterType<HomeController>();
            container.RegisterType<StatisticsController>();

            // Managers
            container.RegisterType<ISecurityManager, SecurityManager>();

            // Repositories
            
            

            return container;
        }
    }
}