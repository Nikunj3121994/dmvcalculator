using System;
using ps.dmv.common.Core;
using ps.dmv.common.Security;
using ps.dmv.domain.data.Entities;
using ps.dmv.domain.data.Enum;
using ps.dmv.interfaces.Processors;

namespace ps.dmv.domain.application.Processors
{
    /// <summary>
    /// DmvCalculationProcessor
    /// </summary>
    public class DmvCalculationProcessor : IDmvCalculationProcessor
    {
        /// <summary>
        /// Calculates the DMV all.
        /// </summary>
        /// <param name="dmvCalculation">The DMV calculation.</param>
        /// <returns></returns>
        public DmvCalculation CalculateDmvAll(DmvCalculation dmvCalculation)
        {
            decimal co2ExhaustTaxRate = this.GetTaxRateForTheGivenCo2Exhaust(
                dmvCalculation.Co2EmissionsValue, dmvCalculation.EnginePowerKw, dmvCalculation.FuelTypeId,
                dmvCalculation.VehicleTypeId, dmvCalculation.AtLeastEightSeatsVehicle, dmvCalculation.EuroExhaustTypeId);

            decimal euroExhaustAdditionalTaxRate = this.GetAdditionalTaxRateBasedonEuroExhaust(dmvCalculation.EuroExhaustTypeId, dmvCalculation.VehicleTypeId);

            decimal displacementAdditionalTaxRate = this.GetTaxRateForAdditionalDisplacementSize(dmvCalculation.EngineDisplacementCcm, dmvCalculation.VehicleTypeId);

            decimal specialAdditionalTaxRate = this.GetSpecialTaxRateAdditionally(
                dmvCalculation.DieselParticlesAbove005Limit, dmvCalculation.FuelTypeId, dmvCalculation.VehicleTypeId, dmvCalculation.EngineTypeId);

            // Tax calculationss
            dmvCalculation.BaseTaxRate = (double)(co2ExhaustTaxRate + euroExhaustAdditionalTaxRate + specialAdditionalTaxRate)/100;

            dmvCalculation.BaseTaxRateValue = dmvCalculation.BaseTaxRate * dmvCalculation.VehicleValue;

            dmvCalculation.AdditionalTaxRate = (double)displacementAdditionalTaxRate/100;

            dmvCalculation.AdditionalTaxRateValue = dmvCalculation.AdditionalTaxRate * dmvCalculation.VehicleValue;

            dmvCalculation.TaxTotalValue = dmvCalculation.BaseTaxRateValue + dmvCalculation.AdditionalTaxRateValue;

            // Other
            dmvCalculation.UserId = ServiceLocator.Instance.Resolve<IUserProvider>().GetCurrentUserId();

            return dmvCalculation;
        }

        /// <summary>
        /// Gets the tax rate for the given co2 exhaust.
        /// </summary>
        /// <param name="co2Exhaust">The co2 exhaust.</param>
        /// <param name="powerKw"></param>
        /// <param name="fuelTypeEnum">The fuel type enum.</param>
        /// <param name="vehicleTypeEnum"></param>
        /// <param name="atLeastEightSeatsVehicle"></param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Not known FuelTypeEnum.  + fuelTypeEnum</exception>
        private decimal GetTaxRateForTheGivenCo2Exhaust(int co2Exhaust, int powerKw, FuelTypeEnum fuelTypeEnum, VehicleTypeEnum vehicleTypeEnum, bool atLeastEightSeatsVehicle, EuroExhaustTypeEnum euroExhaustTypeEnum)
        {
            decimal taxRate = 0;

            if (vehicleTypeEnum == VehicleTypeEnum.Car)
            {
                //Za motorna vozila iz četrtega odstavka tega člena s pogonom na dizelsko gorivo s stopnjo izpusta Euro 6 se upošteva stopnja davka iz lestvice v četrtem odstavku tega člena za bencinsko gorivo.
                if (euroExhaustTypeEnum == EuroExhaustTypeEnum.Euro6 && fuelTypeEnum == FuelTypeEnum.Diesel)
                {
                    fuelTypeEnum = FuelTypeEnum.PetrolRest;
                }

                if (fuelTypeEnum == FuelTypeEnum.PetrolRest || fuelTypeEnum == FuelTypeEnum.Electric)
                {
                    if (co2Exhaust > 0 && co2Exhaust <= 110)
                    {
                        taxRate = 0.5m;
                    }
                    else if (co2Exhaust > 110 && co2Exhaust <= 120)
                    {
                        taxRate = 1;
                    }
                    else if (co2Exhaust > 120 && co2Exhaust <= 130)
                    {
                        taxRate = 1.5m;
                    }
                    else if (co2Exhaust > 130 && co2Exhaust <= 150)
                    {
                        taxRate = 3;
                    }
                    else if (co2Exhaust > 150 && co2Exhaust <= 170)
                    {
                        taxRate = 6;
                    }
                    else if (co2Exhaust > 170 && co2Exhaust <= 190)
                    {
                        taxRate = 9;
                    }
                    else if (co2Exhaust > 190 && co2Exhaust <= 210)
                    {
                        taxRate = 13;
                    }
                    else if (co2Exhaust > 210 && co2Exhaust <= 230)
                    {
                        taxRate = 18;
                    }
                    else if (co2Exhaust > 230 && co2Exhaust <= 250)
                    {
                        taxRate = 23;
                    }
                    else if (co2Exhaust == 0 || co2Exhaust > 250)
                    {
                        taxRate = 28;
                    }
                }
                else if (fuelTypeEnum == FuelTypeEnum.Diesel)
                {
                    if (co2Exhaust > 0 && co2Exhaust <= 110)
                    {
                        taxRate = 1;
                    }
                    else if (co2Exhaust > 110 && co2Exhaust <= 120)
                    {
                        taxRate = 2;
                    }
                    else if (co2Exhaust > 120 && co2Exhaust <= 130)
                    {
                        taxRate = 3;
                    }
                    else if (co2Exhaust > 130 && co2Exhaust <= 150)
                    {
                        taxRate = 6;
                    }
                    else if (co2Exhaust > 150 && co2Exhaust <= 170)
                    {
                        taxRate = 11;
                    }
                    else if (co2Exhaust > 170 && co2Exhaust <= 190)
                    {
                        taxRate = 15;
                    }
                    else if (co2Exhaust > 190 && co2Exhaust <= 210)
                    {
                        taxRate = 18;
                    }
                    else if (co2Exhaust > 210 && co2Exhaust <= 230)
                    {
                        taxRate = 22;
                    }
                    else if (co2Exhaust > 230 && co2Exhaust <= 250)
                    {
                        taxRate = 26;
                    }
                    else if (co2Exhaust == 0 || co2Exhaust > 250)
                    {
                        taxRate = 31;
                    }
                }
                else
                {
                    throw new Exception("Not known FuelTypeEnum. " + fuelTypeEnum);
                }

                //Za motorna vozila iz četrtega odstavka tega člena z najmanj osmimi sedeži se stopnja davka iz četrtega odstavka tega člena zniža za 30%.
                if (atLeastEightSeatsVehicle)
                {
                    taxRate = taxRate - (taxRate * 0.30m);
                }
            }
            else if (vehicleTypeEnum == VehicleTypeEnum.BikeWithEngine || vehicleTypeEnum == VehicleTypeEnum.Motorbike)
            {
                if (powerKw > 0 && powerKw <= 25)
                {
                    taxRate = 1.5m;
                }
                else if (powerKw > 25 && powerKw <= 50)
                {
                    taxRate = 2;
                }
                else if (powerKw > 50 && powerKw <= 75)
                {
                    taxRate = 3;
                }
                else if (powerKw > 75)
                {
                    taxRate = 5;
                }

                if (fuelTypeEnum == FuelTypeEnum.Electric)
                {
                    taxRate = 0.5m;
                }

            }
            else if (vehicleTypeEnum == VehicleTypeEnum.LivingVan)
            {
                if (powerKw > 0 && powerKw <= 60)
                {
                    taxRate = 6;
                }
                else if (powerKw > 60 && powerKw <= 90)
                {
                    taxRate = 9;
                }
                else if (powerKw > 90 && powerKw <= 120)
                {
                    taxRate = 13;
                }
                else if (powerKw > 190)
                {
                    taxRate = 18;
                }

                if (fuelTypeEnum == FuelTypeEnum.Electric)
                {
                    taxRate = 0.5m;
                }
            }
            else
            {
                throw new Exception("Not known VehicleTypeEnum. " + vehicleTypeEnum);
            }

            return taxRate;
        }

        /// <summary>
        /// Gets the additional tax rate basedon euro exhaust.
        /// </summary>
        /// <param name="euroExhaustTypeEnum">The euro exhaust type enum.</param>
        /// <param name="vehicleTypeEnum">The vehicle type enum.</param>
        /// <param name="dieselParticlesAbove005Limit">if set to <c>true</c> [diesel particles above005 limit].</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">
        /// Not known EuroExhaustTypeEnum.  + euroExhaustTypeEnum
        /// or
        /// Not known VehicleTypeEnum.  + vehicleTypeEnum
        /// </exception>
        private decimal GetAdditionalTaxRateBasedonEuroExhaust(EuroExhaustTypeEnum euroExhaustTypeEnum, VehicleTypeEnum vehicleTypeEnum)
        {
            decimal taxRate = 0;

            if (vehicleTypeEnum == VehicleTypeEnum.Car)
            {
                if (euroExhaustTypeEnum == EuroExhaustTypeEnum.Euro1 || euroExhaustTypeEnum == EuroExhaustTypeEnum.Euro2)
                {
                    taxRate = 10;
                }
                else if (euroExhaustTypeEnum == EuroExhaustTypeEnum.Euro3)
                {
                    taxRate = 5;
                }
                else if (euroExhaustTypeEnum == EuroExhaustTypeEnum.Euro4)
                {
                    taxRate = 2;
                }
            }
            else if (vehicleTypeEnum == VehicleTypeEnum.BikeWithEngine || vehicleTypeEnum == VehicleTypeEnum.Motorbike)
            {
                if (euroExhaustTypeEnum == EuroExhaustTypeEnum.Euro1)
                {
                    taxRate = 10;
                }
                else if (euroExhaustTypeEnum == EuroExhaustTypeEnum.Euro2 && vehicleTypeEnum != VehicleTypeEnum.BikeWithEngine)
                {
                    taxRate = 5;
                }
            }
            else if (vehicleTypeEnum == VehicleTypeEnum.LivingVan)
            {
                if (euroExhaustTypeEnum == EuroExhaustTypeEnum.Euro1 || euroExhaustTypeEnum == EuroExhaustTypeEnum.Euro2)
                {
                    taxRate = 10;
                }
                else if (euroExhaustTypeEnum == EuroExhaustTypeEnum.Euro3)
                {
                    taxRate = 5;
                }
                else if (euroExhaustTypeEnum == EuroExhaustTypeEnum.Euro4)
                {
                    taxRate = 2;
                }
            }
            else
            {
                throw new Exception("Not known VehicleTypeEnum. " + vehicleTypeEnum);
            }

            return taxRate;
        }

        /// <summary>
        /// Gets the size of the tax rate for additional displacement.
        /// </summary>
        /// <param name="displacement">The displacement.</param>
        /// <param name="vehicleTypeEnum">The vehicle type enum.</param>
        /// <returns></returns>
        private decimal GetTaxRateForAdditionalDisplacementSize(int displacement, VehicleTypeEnum vehicleTypeEnum)
        {
            decimal taxRate = 0;

            if (vehicleTypeEnum == VehicleTypeEnum.Car)
            {
                if (displacement <= 2499)
                {
                    taxRate = 0;
                }
                else if (displacement >= 2500 && displacement <= 2999)
                {
                    taxRate = 8;
                }
                else if (displacement >= 3000 && displacement <= 3499)
                {
                    taxRate = 10;
                }
                else if (displacement >= 3500 && displacement <= 3999)
                {
                    taxRate = 13;
                }
                else if (displacement >= 4000)
                {
                    taxRate = 16;
                }
            }
            else if (vehicleTypeEnum == VehicleTypeEnum.BikeWithEngine || vehicleTypeEnum == VehicleTypeEnum.Motorbike)
            {
                if (displacement <= 999)
                {
                    taxRate = 0;
                }
                else if (displacement >= 1000)
                {
                    taxRate = 5;
                }
            }

            return taxRate;
        }

        /// <summary>
        /// Gets the special tax rate additionally.
        /// </summary>
        /// <param name="dieselParticlesAbove005Limit">if set to <c>true</c> [diesel particles above005 limit].</param>
        /// <param name="fuelTypeEnum">The fuel type enum.</param>
        /// <param name="vehicleTypeEnum">The vehicle type enum.</param>
        /// <param name="engineTypeEnum">The engine type enum.</param>
        /// <returns></returns>
        private decimal GetSpecialTaxRateAdditionally(bool dieselParticlesAbove005Limit, FuelTypeEnum fuelTypeEnum, VehicleTypeEnum vehicleTypeEnum, EngineTypeEnum engineTypeEnum)
        {
            decimal taxRate = 0;

            if (vehicleTypeEnum == VehicleTypeEnum.Car)
            {
                //Za motorna vozila iz četrtega odstavka tega člena s pogonom na dizelsko gorivo z izpustom trdnih delcev, večjim od 0,005 g/km, se stopnja davka, določena v četrtem odstavku tega člena, poveča za dve odstotni točki, po 1. januarju 2011 pa za pet odstotnih točk.
                if (fuelTypeEnum == FuelTypeEnum.Diesel && dieselParticlesAbove005Limit)
                {
                    taxRate += 5;
                }
            }
            else if (vehicleTypeEnum == VehicleTypeEnum.BikeWithEngine || vehicleTypeEnum == VehicleTypeEnum.Motorbike)
            {
                //Za motorna vozila iz prejšnjega odstavka z dvotaktnim motorjem na notranje zgorevanje, se stopnja davka, določena v prejšnjem odstavku, poveča za tri odstotne točke.
                if (engineTypeEnum == EngineTypeEnum.TwoTacts)
                {
                    taxRate += 3;
                }
            }
            else if (vehicleTypeEnum == VehicleTypeEnum.LivingVan)
            {
                //Za motorna vozila iz osemnajstega odstavka tega člena s pogonom na dizelsko gorivo z izpustom trdnih delcev, večjim od 0,005 g/km, se stopnja davka, določena v osemnajstem odstavku tega člena, poveča za dve odstotni točki, po 1. januarju 2011 pa za pet odstotnih točk.
                if (fuelTypeEnum == FuelTypeEnum.Diesel && dieselParticlesAbove005Limit)
                {
                    taxRate += 5;
                }
            }

            return taxRate;
        }
    }
}
