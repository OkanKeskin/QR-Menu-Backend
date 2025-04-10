using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Commands.RestaurantCommands.RestaurantCommentCommands
{
    public class CreateRestaurantCommentCommands : IRequest
    {
        public string Comment { get; set; }
        public int CommentStar { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
