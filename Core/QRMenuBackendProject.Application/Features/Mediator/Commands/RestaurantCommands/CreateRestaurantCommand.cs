using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Results.RestaurantResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Commands.RestaurantCommands
{
    public class CreateRestaurantCommand :IRequest<RestaurantCreateResponse>
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
		public string ContentType { get; set; } //fotoğrafın eklendiği klasör
        public Guid AccountsId { get; set; }
    }
}
