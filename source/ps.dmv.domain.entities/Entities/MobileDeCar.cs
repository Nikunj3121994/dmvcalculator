using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ps.dmv.domain.data.Entities
{
    public class MobileDeCar
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int DmvCalculationId { get; set; }
        public string Maker { get; set; }
        public string Model { get; set; }
        public bool IsDeleted { get; set; }
        public string UserId { get; set; }

        public virtual DmvCalculation DmvCalculation { get; set; }
    }
}
