using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ps.dmv.domain.data.Entities
{
    /// <summary>
    /// MobileDeCar
    /// </summary>
    public class MobileDeCar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MobileDeCar"/> class.
        /// </summary>
        public MobileDeCar()
        {
            this.DmvCalculation = new DmvCalculation();
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        [DisplayName("Naslov")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the DMV calculation identifier.
        /// </summary>
        /// <value>
        /// The DMV calculation identifier.
        /// </value>
        public int DmvCalculationId { get; set; }

        /// <summary>
        /// Gets or sets the maker.
        /// </summary>
        /// <value>
        /// The maker.
        /// </value>
        [DisplayName("Proizvajalec")]
        public string Maker { get; set; }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        [DisplayName("Model")]
        public string Model { get; set; }

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
        /// Gets or sets the DMV calculation.
        /// </summary>
        /// <value>
        /// The DMV calculation.
        /// </value>
        public virtual DmvCalculation DmvCalculation { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        /// <value>
        /// The created on.
        /// </value>
        [DisplayName("Datum izračuna")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        /// <value>
        /// The image URL.
        /// </value>
        [DisplayName("Slika avtomobila")]
        public string ImageUrl { get; set; }
    }
}
