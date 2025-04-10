using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Commands.RestaurantCommands.RestaurantTableCommands
{
    public class CreateRestaurantTableCommand : IRequest<Guid>
    {
        public string TableNo { get; set; }
        public string QrUrl { get; set; }
        public int TableCapacity { get; set; }
        public Guid RestaurantId { get; set; }
    }
}
