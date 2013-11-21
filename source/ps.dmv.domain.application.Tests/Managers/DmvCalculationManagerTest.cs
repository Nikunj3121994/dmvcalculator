using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using ps.dmv.domain.application.Tests.Core;
using ps.dmv.domain.data.Entities;
using ps.dmv.interfaces.Repositories;

namespace ps.dmv.domain.application.Tests.Managers
{
    [TestFixture]
    public class DmvCalculationManagerTest : BaseTest
    {
        public DmvCalculationManagerTest()
        {
            
        }

        [Test]
        public void Get_Test()
        {
            Mock<IDmvCalculationRepository> dmvCalculationRepository = new Mock<IDmvCalculationRepository>();
            dmvCalculationRepository.Setup(i => i.Get(0)).Returns(new DmvCalculation());
            _container.RegisterInstance(typeof(IDmvCalculationRepository), dmvCalculationRepository.Object);


        }
    }
}
