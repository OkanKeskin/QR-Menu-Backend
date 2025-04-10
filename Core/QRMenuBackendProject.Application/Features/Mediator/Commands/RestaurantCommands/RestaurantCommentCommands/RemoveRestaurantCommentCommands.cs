using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Commands.RestaurantCommands.RestaurantCommentCommands
{
    public class RemoveRestaurantCommentCommands : IRequest
    {
        public Guid Id { get; set; }

        public RemoveRestaurantCommentCommands(Guid id)
        {
            Id = id;
        }
    }
}
