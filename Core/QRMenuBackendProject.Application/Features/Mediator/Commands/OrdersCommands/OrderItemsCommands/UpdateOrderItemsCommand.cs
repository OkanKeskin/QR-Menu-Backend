using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Commands.OrdersCommands.OrderItemsCommands
{
	public class UpdateOrderItemsCommand : IRequest
	{
        public Guid Id { get; set; }
		public int Quantity { get; set; } // Sipariş edilen ürün miktarı
    }
}
