using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Commands.OrdersCommands.OrderItemsCommands;
using QRMenuBackendProject.Domain.Entities;
using QRMenuBackendProject.Domain.Enums;

namespace QRMenuBackendProject.Application.Features.Mediator.Commands.OrdersCommands
{
	public class CreateOrdersCommand :IRequest
	{
		public Guid RestaurantTableId { get; set; }
		public PaymentType PaymentType { get; set; }
		public List<CreateOrderItemsCommand> OrderItems { get; set; }
	}
}
