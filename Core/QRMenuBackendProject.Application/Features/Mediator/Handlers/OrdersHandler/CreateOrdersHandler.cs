using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Commands.OrdersCommands;
using QRMenuBackendProject.Application.Interfaces.OrdersInterface;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.OrdersHandler
{
	public class CreateOrdersHandler : IRequestHandler<CreateOrdersCommand>
	{
		private readonly IOrdersRepository _repository;

		public CreateOrdersHandler(IOrdersRepository repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateOrdersCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateOrder(new CreateOrdersCommand
			{
				RestaurantTableId = request.RestaurantTableId,
				OrderItems = request.OrderItems,
				PaymentType = request.PaymentType,
			});
		}
	}
}
