using QRMenuBackendProject.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Domain.Entities
{
    public class Menu : AuditableEntity
    {
        public string Name { get; set; }
		public Restaurant Restaurant { get; set; }
		public Guid RestaurantId { get; set; }
		public ICollection<MenuItem> MenuItems { get; set; }
    }
}
