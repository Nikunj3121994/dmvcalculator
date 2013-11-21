using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using ps.dmv.common.Core;
using ps.dmv.common.Security;
using ps.dmv.domain.application.Managers;
using ps.dmv.domain.application.Processors;
using ps.dmv.interfaces.Managers;
using ps.dmv.interfaces.Processors;

namespace ps.dmv.domain.application.Tests.Core
{
    /// <summary>
    /// BaseTest
    /// </summary>
    public class BaseTest
    {
        protected UnityContainer _container;

        [SetUp]
        public void SetUpCore()
        {
            _container = new UnityContainer();

            // Processors
            _container.RegisterType<IMobileDeProcessor, MobileDeProcessor>();

            // Managers
            _container.RegisterType<IDmvCalculationManager, DmvCalculationManager>();

            // Providers
            Mock<IUserProvider> userProviderMock = new Mock<IUserProvider>();
            userProviderMock.Setup(i => i.GetCurrentUserId()).Returns("userid");
            _container.RegisterInstance(typeof(IUserProvider), userProviderMock.Object);

            // setup service locator container
            ServiceLocator.Instance.SetContainer(_container);
        }
    }
}
