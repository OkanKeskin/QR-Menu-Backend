using QRMenuBackendProject.Domain.Entities.Base;
using QRMenuBackendProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Domain.Entities
{
    public class Accounts : AuditableEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public AccountsType Type { get; set; }

        public List<RestaurantEmployee> Employees { get; set; }
        public List<Company> Company { get; set; }
        public List<Customer> Coustomer { get; set; }
		public ICollection<Restaurant> Restaurants { get; set; }
	}
}
