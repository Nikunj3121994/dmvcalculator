using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ps.dmv.domain.data.Enum;

namespace ps.dmv.domain.data.Entities
{
    /// <summary>
    /// ImportMobileDe
    /// </summary>
    public class ImportMobileDe
    {
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        [Url]
        [Required(ErrorMessage = "{0} je obvezno polje")]
        [DisplayName("URL")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the vehicle type identifier.
        /// </summary>
        /// <value>
        /// The vehicle type identifier.
        /// </value>
        [Required]
        [DisplayName("Vrsta vozila")]
        public VehicleTypeEnum VehicleTypeId { get; set; }
    }
}
