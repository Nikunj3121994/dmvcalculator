using System;

namespace ps.dmv.domain.data.Entities
{
    public class DmvCalculation
    {
        public int Id { get; set; }
        public DateTime DateOfCalculation { get; set; }
        public int VehicleTypeId { get; set; }
        public int FuelTypeId { get; set; }
        public short Co2EmissionsValue { get; set; }
        public int EuroExhaustTypeId { get; set; }
        public bool AtLeastEightSeatsVehicle { get; set; }
        public bool DieselParticlesAbove005Limit { get; set; }
        public int EnginePowerKw { get; set; }
        public int EngineDisplacementCcm { get; set; }
        public int EngineTypeId { get; set; }
        public int VehicleValue { get; set; }
        public int BaseTaxRate { get; set; }
        public double BaseTaxRateValue { get; set; }
        public int AdditionalTaxRate { get; set; }
        public double AdditionalTaxRateValue { get; set; }
        public double TaxTotalValue { get; set; }
        public bool IsDeleted { get; set; }
        public string UserId { get; set; }
    }
}
