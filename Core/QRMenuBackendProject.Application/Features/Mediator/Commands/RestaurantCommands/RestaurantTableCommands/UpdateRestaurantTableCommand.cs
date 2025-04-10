using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Commands.RestaurantCommands.RestaurantTableCommands
{
    public class UpdateRestaurantTableCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string TableNo { get; set; }
        public int TableCapacity { get; set; }
    }
}
