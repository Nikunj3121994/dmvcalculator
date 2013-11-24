using System;
using System.ComponentModel;
using ps.dmv.domain.data.Enum;

namespace ps.dmv.domain.data.Entities
{
    /// <summary>
    /// DmvCalculation
    /// </summary>
    public class DmvCalculation
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the date of calculation.
        /// </summary>
        /// <value>
        /// The date of calculation.
        /// </value>
        [DisplayName("Datum izračuna")]
        public DateTime DateOfCalculation { get; set; }

        /// <summary>
        /// Gets or sets the vehicle type identifier.
        /// </summary>
        /// <value>
        /// The vehicle type identifier.
        /// </value>
        [DisplayName("Vozilo")]
        public VehicleTypeEnum VehicleTypeId { get; set; }

        /// <summary>
        /// Gets or sets the fuel type identifier.
        /// </summary>
        /// <value>
        /// The fuel type identifier.
        /// </value>
        [DisplayName("Gorivo")]
        public FuelTypeEnum FuelTypeId { get; set; }

        /// <summary>
        /// Gets or sets the co2 emissions value.
        /// </summary>
        /// <value>
        /// The co2 emissions value.
        /// </value>
        [DisplayName("Co2 izpusti")]
        public short Co2EmissionsValue { get; set; }

        /// <summary>
        /// Gets or sets the euro exhaust type identifier.
        /// </summary>
        /// <value>
        /// The euro exhaust type identifier.
        /// </value>
        [DisplayName("EURO izpuh")]
        public EuroExhaustTypeEnum EuroExhaustTypeId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [at least eight seats vehicle].
        /// </summary>
        /// <value>
        /// <c>true</c> if [at least eight seats vehicle]; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Najmanj vozilo z 8 sedeži")]
        public bool AtLeastEightSeatsVehicle { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [diesel particles above005 limit].
        /// </summary>
        /// <value>
        /// <c>true</c> if [diesel particles above005 limit]; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Brez DPF filtra")]
        public bool DieselParticlesAbove005Limit { get; set; }

        /// <summary>
        /// Gets or sets the engine power kw.
        /// </summary>
        /// <value>
        /// The engine power kw.
        /// </value>
        [DisplayName("Moc motorja [kw]")]
        public int EnginePowerKw { get; set; }

        /// <summary>
        /// Gets or sets the engine displacement CCM.
        /// </summary>
        /// <value>
        /// The engine displacement CCM.
        /// </value>
        [DisplayName("Prostornina motorja [ccm]")]
        public int EngineDisplacementCcm { get; set; }

        /// <summary>
        /// Gets or sets the engine type identifier.
        /// </summary>
        /// <value>
        /// The engine type identifier.
        /// </value>
        [DisplayName("Tip motorja")]
        public EngineTypeEnum EngineTypeId { get; set; }

        /// <summary>
        /// Gets or sets the vehicle value.
        /// </summary>
        /// <value>
        /// The vehicle value.
        /// </value>
        [DisplayName("Cena vozila")]
        public double VehicleValue { get; set; }

        /// <summary>
        /// Gets or sets the base tax rate.
        /// </summary>
        /// <value>
        /// The base tax rate.
        /// </value>
        [DisplayName("Osnovni davek [%]")]
        public double BaseTaxRate { get; set; }

        /// <summary>
        /// Gets or sets the base tax rate value.
        /// </summary>
        /// <value>
        /// The base tax rate value.
        /// </value>
        [DisplayName("Znesek osnovnega davka")]
        public double BaseTaxRateValue { get; set; }

        /// <summary>
        /// Gets or sets the additional tax rate.
        /// </summary>
        /// <value>
        /// The additional tax rate.
        /// </value>
        [DisplayName("Dodatni davek [%]")]
        public double AdditionalTaxRate { get; set; }

        /// <summary>
        /// Gets or sets the additional tax rate value.
        /// </summary>
        /// <value>
        /// The additional tax rate value.
        /// </value>
        [DisplayName("Znesek dodatnega davka")]
        public double AdditionalTaxRateValue { get; set; }

        /// <summary>
        /// Gets or sets the tax total value.
        /// </summary>
        /// <value>
        /// The tax total value.
        /// </value>
        [DisplayName("Znesek celotnega davka")]
        public double TaxTotalValue { get; set; }

        /// <summary>
        /// Gets the total vehicle value with tax.
        /// </summary>
        /// <value>
        /// The total vehicle value with tax.
        /// </value>
        [DisplayName("Končni znesek vozila z davkom")]
        public double TotalVehicleValueWithTax
        {
            get { return this.VehicleValue + this.TaxTotalValue; }
        }

        /// <summary>
        /// Gets the total vehicle tax rate.
        /// </summary>
        /// <value>
        /// The total vehicle tax rate.
        /// </value>
        [DisplayName("Skupni davek [%]")]
        public double TotalVehicleTaxRate
        {
            get { return (this.BaseTaxRate + this.AdditionalTaxRate); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [is deleted].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is deleted]; otherwise, <c>false</c>.
        /// </value>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the create on.
        /// </summary>
        /// <value>
        /// The create on.
        /// </value>
        [DisplayName("Datum izračuna")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the mobile de car.
        /// </summary>
        /// <value>
        /// The mobile de car.
        /// </value>
        public virtual MobileDeCar MobileDeCar { get; set; }

        /// <summary>
        /// Gets or sets the mobile de car identifier.
        /// </summary>
        /// <value>
        /// The mobile de car identifier.
        /// </value>
        public int? MobileDeCarId { get; set; }
    }
}
