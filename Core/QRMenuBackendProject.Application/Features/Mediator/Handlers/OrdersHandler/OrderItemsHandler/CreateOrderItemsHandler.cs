using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Commands.OrdersCommands.OrderItemsCommands;
using QRMenuBackendProject.Application.Interfaces.OrderItemsInterface;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.OrdersHandler.OrderItemsHandler
{
	public class CreateOrderItemsHandler : IRequestHandler<CreateOrderItemsCommand>
	{
		private readonly IOrderItemsRepository _repository;

		public CreateOrderItemsHandler(IOrderItemsRepository repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateOrderItemsCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateOrderItems(new CreateOrderItemsCommand
			{
				MenuItemId = request.MenuItemId,
				Quantity = request.Quantity,
				Price = request.Price,
				OrdersId = request.OrdersId,
			});
		}
	}
}
