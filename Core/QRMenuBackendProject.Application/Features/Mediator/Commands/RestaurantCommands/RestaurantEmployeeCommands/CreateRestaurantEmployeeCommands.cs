using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Commands.RestaurantCommands.RestaurantEmployeeCommands
{
    public class CreateRestaurantEmployeeCommands : IRequest
    {
        public string NameSurname { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfStart { get; set; }
        public Guid RestaurantId { get; set; }
    }
}
