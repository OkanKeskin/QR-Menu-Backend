using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Commands.OrdersCommands.OrderItemsCommands;
using QRMenuBackendProject.Application.Interfaces.OrderItemsInterface;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.OrdersHandler.OrderItemsHandler
{
	public class RemoveOrderItemsHandler : IRequestHandler<RemoveOrderItemsCommand>
	{
		private readonly IOrderItemsRepository _repository;

		public RemoveOrderItemsHandler(IOrderItemsRepository repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveOrderItemsCommand request, CancellationToken cancellationToken)
		{
			await _repository.RemoveOrderItem(request.Id);
		}
	}
}
