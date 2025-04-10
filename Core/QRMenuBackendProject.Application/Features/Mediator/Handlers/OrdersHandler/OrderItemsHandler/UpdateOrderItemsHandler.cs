using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Commands.OrdersCommands.OrderItemsCommands;
using QRMenuBackendProject.Application.Interfaces.OrderItemsInterface;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.OrdersHandler.OrderItemsHandler
{
	public class UpdateOrderItemsHandler : IRequestHandler<UpdateOrderItemsCommand>
	{
		private readonly IOrderItemsRepository _repository;

		public UpdateOrderItemsHandler(IOrderItemsRepository repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateOrderItemsCommand request, CancellationToken cancellationToken)
		{
			await _repository.UpdateOrderItems(new UpdateOrderItemsCommand
			{
				Id = request.Id,
				Quantity = request.Quantity,
			});
		}
	}
}
