using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using ps.dmv.common.Core;
using ps.dmv.common.Helpers;
using ps.dmv.common.Security;
using ps.dmv.domain.data.Entities;
using ps.dmv.domain.data.Enum;
using ps.dmv.interfaces.Processors;

namespace ps.dmv.domain.application.Processors
{
    /// <summary>
    /// MobileDeProcessor
    /// </summary>
    public class MobileDeProcessor : IMobileDeProcessor
    {
        /// <summary>
        /// Imports the car from mobile de.
        /// </summary>
        /// <param name="importMobileDe">The import mobile de.</param>
        /// <returns></returns>
        public async Task<MobileDeCar> ImportCarFromMobileDe(ImportMobileDe importMobileDe)
        {
            WebPageParser webPageParser = new WebPageParser();

            await webPageParser.ParseWebPage(importMobileDe.Url);

            MobileDeCar mobileDeCar = new MobileDeCar();

            // Default setting for car

            mobileDeCar.Url = importMobileDe.Url;
            mobileDeCar.DmvCalculation.VehicleTypeId = importMobileDe.VehicleTypeId;
            mobileDeCar.DmvCalculation.DateOfCalculation = DateTime.UtcNow;
            mobileDeCar.DmvCalculation.EngineTypeId = EngineTypeEnum.FourTactsRest;
            mobileDeCar.UserId = ServiceLocator.Instance.Resolve<IUserProvider>().GetCurrentUserId();
            
            //

            string resultNode = null;
            string webPageNode = null;

            webPageNode = webPageParser.GetWebPageNode("co2EmissionValue");
            if (webPageNode != null)
            {
                resultNode = webPageParser.GetWebPageNodeNumericContent(webPageNode);
                mobileDeCar.DmvCalculation.Co2EmissionsValue = Convert.ToInt16(resultNode);
            }
            
            webPageNode = webPageParser.GetWebPageNode("kW (");
            if (webPageNode != null)
            {
                resultNode = webPageParser.GetWebPageNodeNumericContent(webPageNode);
                mobileDeCar.DmvCalculation.EnginePowerKw = Convert.ToInt16(resultNode);
            }

            webPageNode = webPageParser.GetWebPageNode("\nEuro");
            if (webPageNode != null)
            {
                resultNode = webPageParser.GetWebPageNodeStringContent(webPageNode);
                mobileDeCar.DmvCalculation.EuroExhaustTypeId = EnumHelper.GetEnumValue<EuroExhaustTypeEnum>(resultNode);
            }
            else
            {
                // Defaut EURO
                mobileDeCar.DmvCalculation.EuroExhaustTypeId = EuroExhaustTypeEnum.Euro1;
            }

            //By law every EURO5+ have to have DPF filter, most of them had for the EURO4
            if ((int)mobileDeCar.DmvCalculation.EuroExhaustTypeId < 4)
            {
                mobileDeCar.DmvCalculation.DieselParticlesAbove005Limit = true;
            }

            // Set default and handlig of the FuelType
            mobileDeCar.DmvCalculation.FuelTypeId = FuelTypeEnum.PetrolRest;
            webPageNode = webPageParser.GetWebPageNode("p>\nPetrol");
            webPageNode = webPageNode ?? webPageParser.GetWebPageNode("p>\nBenzin");
            webPageNode = webPageNode ?? webPageParser.GetWebPageNode("p>\nHybrid (Benzin");
            if (webPageNode != null)
            {
                resultNode = webPageParser.GetWebPageNodeStringContent(webPageNode);
                mobileDeCar.DmvCalculation.FuelTypeId = FuelTypeEnum.PetrolRest;
            }

            webPageNode = webPageParser.GetWebPageNode("p>\nDiesel");
            webPageNode = webPageNode ?? webPageParser.GetWebPageNode("p>\nHybrid (Diesel");
            if (webPageNode != null)
            {
                resultNode = webPageParser.GetWebPageNodeStringContent(webPageNode);
                mobileDeCar.DmvCalculation.FuelTypeId = FuelTypeEnum.Diesel;
            }

            webPageNode = webPageParser.GetWebPageNode(" cm³");
            if (webPageNode != null)
            {
                resultNode = webPageParser.GetWebPageNodeNumericContent(webPageNode);
                mobileDeCar.DmvCalculation.EngineDisplacementCcm = Convert.ToInt32(resultNode);
            }

            webPageNode = webPageParser.GetWebPageNode("pricePrimaryCountryOfSale priceGross");
            if (webPageNode != null)
            {
                resultNode = webPageParser.GetWebPageNodeNumericContent(webPageNode);
                mobileDeCar.DmvCalculation.VehicleValue = Convert.ToInt32(resultNode);
            }

            webPageNode = webPageParser.GetWebPageNode("h1>\n");
            if (webPageNode != null)
            {
                resultNode = webPageParser.GetWebPageNodeStringContent(webPageNode);
                mobileDeCar.Model = resultNode;
                mobileDeCar.Maker = resultNode.Split(' ').FirstOrDefault();
            }

            webPageNode = webPageParser.GetWebPageNode("img class=\"currentImage\" src");
            if (webPageNode != null)
            {
                resultNode = webPageParser.GetWebPageAttributeStringContent(webPageNode, "src");
                mobileDeCar.ImageUrl = resultNode;
            }

            return mobileDeCar;
        }
    }
}
