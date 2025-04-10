using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Results.RestaurantResults.RestaurantEmployees
{
    public class GetRestaurantEmployeeByIdQueryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public string TCKN { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public DateTime DateOfStart { get; set; }
        public Guid RestaurantId { get; set; }
    }
}
