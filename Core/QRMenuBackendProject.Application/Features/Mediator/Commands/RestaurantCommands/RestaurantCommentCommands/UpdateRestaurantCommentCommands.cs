using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Commands.RestaurantCommands.RestaurantCommentCommands
{
    public class UpdateRestaurantCommentCommands : IRequest
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }

    }
}
