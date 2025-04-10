using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Commands.RestaurantCommands.RestaurantTableCommands
{
    public class RemoveRestaurantTableCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public RemoveRestaurantTableCommand(Guid id)
        {
            Id = id;
        }
    }
}
