using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Results.OrdersResults.OrderItemsResults;
using QRMenuBackendProject.Application.Interfaces.OrderItemsInterface;
using QRMenuBackendProject.Application.Features.Mediator.Queries.OrdersQueries.OrderItemsQueries;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.OrdersHandler.OrderItemsHandler
{
	public class GetOrderItemsByIdQueryHandler : IRequestHandler<GetOrderItemsByIdQuery, GetOrderItemsByIdQueryResult>
	{
		private readonly IOrderItemsRepository _repository;

		public GetOrderItemsByIdQueryHandler(IOrderItemsRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetOrderItemsByIdQueryResult> Handle(GetOrderItemsByIdQuery request, CancellationToken cancellationToken)
		{
			var result = await _repository.FindOrderItem(request.Id);

			GetOrderItemsByIdQueryResult orderitem = new GetOrderItemsByIdQueryResult();
			orderitem.Id = result.Id;
			orderitem.MenuItemId = result.MenuItemId;
			orderitem.MenuItemName = result.MenuItems.Name;
			orderitem.OrdersId = result.OrdersId;
			orderitem.Price = result.Price;
			orderitem.Quantity = result.Quantity;
			return orderitem;
		}

	}
}
