namespace ps.dmv.domain.data.Entities
{
    /// <summary>
    /// DmvCalculationResult
    /// </summary>
    public class DmvCalculationResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DmvCalculationResult"/> class.
        /// </summary>
        /// <param name="dmvCalculation">The DMV calculation.</param>
        public DmvCalculationResult(DmvCalculation dmvCalculation)
        {
            this.DmvCalculation = dmvCalculation;
            this.MobileDeCar = dmvCalculation.MobileDeCar;
        }

        public DmvCalculationResult(DmvCalculation dmvCalculation, MobileDeCar mobileDeCar) : this(dmvCalculation)
        {
            this.MobileDeCar = mobileDeCar;
        }

        /// <summary>
        /// Gets or sets the DMV calculation.
        /// </summary>
        /// <value>
        /// The DMV calculation.
        /// </value>
        public DmvCalculation DmvCalculation { get; set; }

        /// <summary>
        /// Gets or sets the mobile de car.
        /// </summary>
        /// <value>
        /// The mobile de car.
        /// </value>
        public MobileDeCar MobileDeCar { get; set; }
    }
}
