using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Results.OrdersResults.OrderItemsResults;
using QRMenuBackendProject.Application.Interfaces.OrderItemsInterface;
using QRMenuBackendProject.Application.Features.Mediator.Queries.OrdersQueries.OrderItemsQueries;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.OrdersHandler.OrderItemsHandler
{
	public class GetAllOrderItemsHandler : IRequestHandler<GetOrderItemsQuery, List<GetOrderItemsQueryResult>>
	{
		private readonly IOrderItemsRepository _repository;

		public GetAllOrderItemsHandler(IOrderItemsRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetOrderItemsQueryResult>> Handle(GetOrderItemsQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.ListAllOrderItems();

			List<GetOrderItemsQueryResult> result = new List<GetOrderItemsQueryResult>();

			if (values != null)
			{
				foreach (var products in values)
				{
					GetOrderItemsQueryResult orderitem = new GetOrderItemsQueryResult();
					orderitem.Id = products.Id;
					orderitem.MenuItemId = products.MenuItemId;
					orderitem.MenuItemName = products.MenuItems.Name;
					orderitem.OrdersId = products.OrdersId;
					orderitem.Price = products.Price;
					orderitem.Quantity = products.Quantity;
					result.Add(orderitem);
				}
			}
			return result;
		}
	}
}
