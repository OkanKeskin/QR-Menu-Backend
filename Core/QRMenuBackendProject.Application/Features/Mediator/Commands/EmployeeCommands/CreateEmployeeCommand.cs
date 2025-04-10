using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Commands.EmployeeCommands
{
    public class CreateEmployeeCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfStart { get; set; }
        public string TCKN { get; set; }
        public string Email { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid AccountsId { get; set; }
    }
}
