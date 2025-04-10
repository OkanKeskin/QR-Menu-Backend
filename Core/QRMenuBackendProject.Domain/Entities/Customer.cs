using QRMenuBackendProject.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Domain.Entities
{
    public class Customer : AuditableEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; } 
        public string PhoneNumber { get; set; }
        public string? Image { get; set; }
        public Guid AccountsId { get; set; }
        public Accounts Accounts { get; set; }
        public FavoriteRestaurant FavoriteRestaurants { get; set; }
    }
}
