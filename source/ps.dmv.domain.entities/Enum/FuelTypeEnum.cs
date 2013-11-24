using System.ComponentModel.DataAnnotations;

namespace ps.dmv.domain.data.Enum
{
    /// <summary>
    /// FuelTypeEnum
    /// </summary>
    public enum FuelTypeEnum
    {
        /// <summary>
        /// The petrol rest
        /// </summary>
        [Display(Name = "Bencin (+vse ostalo)")]
        PetrolRest = 1,

        /// <summary>
        /// The diesel
        /// </summary>
        [Display(Name = "Dizel")]
        Diesel,

        /// <summary>
        /// The electric
        /// </summary>
        [Display(Name = "Elektrika")]
        Electric
    }
}
