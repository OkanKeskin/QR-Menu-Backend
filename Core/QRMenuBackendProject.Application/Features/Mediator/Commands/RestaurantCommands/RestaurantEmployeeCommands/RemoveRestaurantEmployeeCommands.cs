using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Commands.RestaurantCommands.RestaurantEmployeeCommands
{
    public class RemoveRestaurantEmployeeCommands : IRequest
    {
        public Guid Id { get; set; }

        public RemoveRestaurantEmployeeCommands(Guid id)
        {
            Id = id;
        }
    }
}
