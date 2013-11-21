using NUnit.Framework;
using ps.dmv.common.Core;
using ps.dmv.domain.application.Tests.Core;
using ps.dmv.domain.data.Entities;
using ps.dmv.domain.data.Enum;
using ps.dmv.interfaces.Processors;

namespace ps.dmv.domain.application.Tests.Processor
{
    [TestFixture]
    public class MobileDeProcessorTest : BaseTest
    {
        private const string _testCarUrlOK1 = "http://suchen.mobile.de/auto-inserat/bmw-750i-v8-top-z-absoluteste-super-ausstg-l%C3%BCdenscheid/184818835.html?lang=en&pageNumber=2&__lp=11&scopeId=C&sortOption.sortBy=price.consumerGrossEuro&makeModelVariant1.makeId=3500&makeModelVariant1.modelId=40&makeModelVariant1.searchInFreetext=false&makeModelVariant2.searchInFreetext=false&makeModelVariant3.searchInFreetext=false&minFirstRegistrationDate=2005-01-01&features=ELECTRIC_HEATED_SEATS&features=FULL_SERVICE_HISTORY&negativeFeatures=EXPORT&maxMileage=200000&numberOfPreviousOwners=2";
        private const string _testCarUrlOK2 = "http://suchen.mobile.de/auto-inserat/bmw-520-lim-520d-neuwagen-3km-facelift-waldbr%C3%B6l-br%C3%B6l/186752112.html?lang=de&pageNumber=1&__lp=182&scopeId=C&sortOption.sortBy=price.consumerGrossEuro&makeModelVariant1.makeId=3500&makeModelVariant1.modelId=16%2C17%2C74%2C18%2C19%2C20%2C21%2C22%2C65%2C23%2C66%2C24%2C25%2C26%2C67%2C70&makeModelVariant1.searchInFreetext=false&makeModelVariant2.searchInFreetext=false&makeModelVariant3.searchInFreetext=false&minFirstRegistrationDate=2013-01-01&negativeFeatures=EXPORT";
        private const string _testCarUrlOK3 = "http://suchen.mobile.de/auto-inserat/bmw-730i-nightvision-leder-klima-oberhaching-bei-m%C3%BC/187001743.html?lang=de&pageNumber=1&__lp=1&scopeId=C&sortOption.sortBy=price.consumerGrossEuro&makeModelVariant1.makeId=3500&makeModelVariant1.modelId=35&makeModelVariant1.searchInFreetext=false&makeModelVariant2.searchInFreetext=false&makeModelVariant3.searchInFreetext=false&minPowerAsArray=184&minPowerAsArray=KW&fuels=PETROL&minFirstRegistrationDate=2005-01-01&negativeFeatures=EXPORT";
        private const string _testCarUrlOK4 = "http://suchen.mobile.de/auto-inserat/mercedes-benz-190e-automatik-schiebedach-donnersdorf/183673927.html?lang=en&pageNumber=1&action=topOfPage&__lp=71625&scopeId=C&sortOption.sortBy=searchNetGrossPrice&makeModelVariant1.searchInFreetext=false&makeModelVariant2.searchInFreetext=false&makeModelVariant3.searchInFreetext=false&damageUnrepaired=ALSO_DAMAGE_UNREPAIRED&export=ALSO_EXPORT";
        private const string _testCarUrlFAIL1 = "http://suchen.mobile.de/auto-inserat/bmw-750i-xenon-navi-professional-leder-1-hand-b%C3%BCnde/186338753.html?lang=en&pageNumber=1&__lp=9&scopeId=C&sortOption.sortBy=price.consumerGrossEuro&makeModelVariant1.makeId=3500&makeModelVariant1.modelId=40&makeModelVariant1.searchInFreetext=false&makeModelVariant2.searchInFreetext=false&makeModelVariant3.searchInFreetext=false&maxPowerAsArray=295&maxPowerAsArray=KW&minFirstRegistrationDate=2005-01-01&negativeFeatures=EXPORT&soid=2544089";


        [SetUp]
        public void Init()
        {
            
        }

        [Test]
        [TestCase(_testCarUrlOK1, 271)]
        [TestCase(_testCarUrlFAIL1, 0)]
        public async void ParseGetCo2_GivenWebPageSample_GetValueImportCarFromMobileDeTestCo2(string url, int result)
        {
            // arrange
            IMobileDeProcessor mobileDeProcessor = ServiceLocator.Instance.Resolve<IMobileDeProcessor>();
            ImportMobileDe importMobileDe = new ImportMobileDe() { Url = url, VehicleTypeId = VehicleTypeEnum.Car };

            // act
            MobileDeCar mobileDeCar = await mobileDeProcessor.ImportCarFromMobileDe(importMobileDe);

            //assert
            Assert.IsTrue(mobileDeCar.DmvCalculation.Co2EmissionsValue == result);
        }

        [Test]
        public async void ImportCarFromMobileDeTestkW()
        {
            // arrange
            IMobileDeProcessor mobileDeProcessor = ServiceLocator.Instance.Resolve<IMobileDeProcessor>();
            ImportMobileDe importMobileDe = new ImportMobileDe() { Url = _testCarUrlOK1, VehicleTypeId = VehicleTypeEnum.Car };

            // act
            MobileDeCar mobileDeCar = await mobileDeProcessor.ImportCarFromMobileDe(importMobileDe);

            //assert
            Assert.IsTrue(mobileDeCar.DmvCalculation.EnginePowerKw > 0);
        }

        [Test]
        [TestCase(_testCarUrlOK1, EuroExhaustTypeEnum.Euro4)]
        [TestCase(_testCarUrlOK4, EuroExhaustTypeEnum.None)]
        public async void ImportCarFromMobileDeEuro(string url, EuroExhaustTypeEnum expected)
        {
            // arrange
            IMobileDeProcessor mobileDeProcessor = ServiceLocator.Instance.Resolve<IMobileDeProcessor>();
            ImportMobileDe importMobileDe = new ImportMobileDe() { Url = url, VehicleTypeId = VehicleTypeEnum.Car };

            // act
            MobileDeCar mobileDeCar = await mobileDeProcessor.ImportCarFromMobileDe(importMobileDe);

            //assert
            Assert.IsTrue(mobileDeCar.DmvCalculation.EuroExhaustTypeId == expected);
        }

        [Test]
        [TestCase(_testCarUrlOK1)]
        [TestCase(_testCarUrlOK3)]
        public async void ImportCarFromMobileDeFuel(string url)
        {
            // arrange
            IMobileDeProcessor mobileDeProcessor = ServiceLocator.Instance.Resolve<IMobileDeProcessor>();
            ImportMobileDe importMobileDe = new ImportMobileDe() { Url = url, VehicleTypeId = VehicleTypeEnum.Car };

            // act
            MobileDeCar mobileDeCar = await mobileDeProcessor.ImportCarFromMobileDe(importMobileDe);

            //assert
            Assert.IsTrue(mobileDeCar.DmvCalculation.FuelTypeId == FuelTypeEnum.PetrolRest);
        }

        [Test]
        public async void ImportCarFromMobileDeCcm()
        {
            // arrange
            IMobileDeProcessor mobileDeProcessor = ServiceLocator.Instance.Resolve<IMobileDeProcessor>();
            ImportMobileDe importMobileDe = new ImportMobileDe() { Url = _testCarUrlOK1, VehicleTypeId = VehicleTypeEnum.Car };

            // act
            MobileDeCar mobileDeCar = await mobileDeProcessor.ImportCarFromMobileDe(importMobileDe);

            //assert
            Assert.IsTrue(mobileDeCar.DmvCalculation.EngineDisplacementCcm > 0);
        }

        [Test]
        [TestCase(_testCarUrlOK1)]
        [TestCase(_testCarUrlOK2)]
        public async void ImportCarFromMobileDeValue(string url)
        {
            // arrange
            IMobileDeProcessor mobileDeProcessor = ServiceLocator.Instance.Resolve<IMobileDeProcessor>();
            ImportMobileDe importMobileDe = new ImportMobileDe() { Url = url, VehicleTypeId = VehicleTypeEnum.Car };

            // act
            MobileDeCar mobileDeCar = await mobileDeProcessor.ImportCarFromMobileDe(importMobileDe);

            //assert
            Assert.IsTrue(mobileDeCar.DmvCalculation.VehicleValue > 0);
        }
    }
}
