using System.Web.Mvc;
using Microsoft.Practices.Unity;
using ps.dmv.common.Core;
using ps.dmv.common.Security;
using ps.dmv.domain.application.Managers;
using ps.dmv.domain.application.Processors;
using ps.dmv.infrastructure.Repositories;
using ps.dmv.interfaces.Managers;
using ps.dmv.interfaces.Processors;
using ps.dmv.interfaces.Providers;
using ps.dmv.interfaces.Repositories;
using ps.dmv.web.Controllers;
using ps.dmv.web.Infrastructure.Security;

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

            container.RegisterType<ApiDmvCalculationController>();
            container.RegisterType<DmvController>();
            container.RegisterType<ExternalImportCarDataController>();
            container.RegisterType<HomeController>();
            container.RegisterType<StatisticsController>();
            container.RegisterType<ApiCodeTableController>();

            // Managers
            container.RegisterType<ISecurityManager, SecurityManager>();
            container.RegisterType<IDmvCalculationManager, DmvCalculationManager>();
            container.RegisterType<ICodeTableManager, CodeTableManager>();
            container.RegisterType<IMobileDeManager, MobileDeManager>();
            container.RegisterType<IStatisticsManager, StatisticsManager>();

            // Repositories
            container.RegisterType<IDmvCalculationRepository, DmvCalculationRepository>();
            container.RegisterType<IVehicleTypeRepository, VehicleTypeRepository>();
            container.RegisterType<IEngineTypeRepository, EngineTypeRepository>();
            container.RegisterType<IEuroExhaustTypeRepository, EuroExhaustTypeRepository>();
            container.RegisterType<IFuelTypeRepository, FuelTypeRepository>();
            container.RegisterType<IMobileDeRepository, MobileDeRepository>();
            container.RegisterType<IStatisticsRepository, StatisticsRepository>();

            // Processors
            container.RegisterType<IDmvCalculationProcessor, DmvCalculationProcessor>();
            container.RegisterType<IMobileDeProcessor, MobileDeProcessor>();

            // Providers
            container.RegisterType<IUserProvider, UserProvider>();
            container.RegisterType<IAuthenticationProvider, AuthenticationProvider>();

            return container;
        }
    }
}