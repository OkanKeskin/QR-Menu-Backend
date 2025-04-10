using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Commands.RestaurantCommands
{
    public class RemoveRestaurantCommand : IRequest
    {
        public Guid Id { get; set; }

        public RemoveRestaurantCommand(Guid id)
        {
            Id = id;
        }
    }
}
