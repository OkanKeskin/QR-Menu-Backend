using QRMenuBackendProject.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Domain.Entities
{
    public class RestaurantComment : AuditableEntity
    {
        public string Comment { get; set; }
        public int CommentStar { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid CustomerId { get; set; }
        public Restaurant Restaurant { get; set; }
        public Customer Customer { get; set; }
    }
}
