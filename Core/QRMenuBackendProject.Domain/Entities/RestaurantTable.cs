using QRMenuBackendProject.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Domain.Entities
{
    public class RestaurantTable : AuditableEntity
    {
        public string TableNo{ get; set; }
        public string QrUrl { get; set; }
        public int TableCapacity { get; set; }
        public bool Status { get; set; } = false;
        public Guid RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
