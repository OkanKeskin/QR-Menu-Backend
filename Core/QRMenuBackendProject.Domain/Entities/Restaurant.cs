using QRMenuBackendProject.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Domain.Entities
{
    public class Restaurant : AuditableEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
		public string ContentType { get; set; } //fotoğrafın eklendiği klasör
		public List<RestaurantEmployee> Employees { get; set; }
        public List<RestaurantTable> Tables { get; set; }
        public Menu Menu { get; set; }
        public Accounts Accounts { get; set; }
        public Guid AccountsId { get; set; }
    }
}
