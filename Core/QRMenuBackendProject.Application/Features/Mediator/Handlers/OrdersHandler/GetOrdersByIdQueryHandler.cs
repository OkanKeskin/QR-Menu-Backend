using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Queries.OrdersQuries;
using QRMenuBackendProject.Application.Features.Mediator.Results.OrdersResults;
using QRMenuBackendProject.Application.Features.Mediator.Results.OrdersResults.OrderItemsResults;
using QRMenuBackendProject.Application.Interfaces.OrdersInterface;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.OrdersHandler
{
	public class GetOrdersByIdQueryHandler : IRequestHandler<GetOrdersByIdQuery, GetOrdersByIdQueryResult>
	{
		private readonly IOrdersRepository _repository;

		public GetOrdersByIdQueryHandler(IOrdersRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetOrdersByIdQueryResult> Handle(GetOrdersByIdQuery request, CancellationToken cancellationToken)
		{
			var result = await _repository.FindOrder(request.Id);
			GetOrdersByIdQueryResult item = new GetOrdersByIdQueryResult();
			if(result != null)
			{
				item.Id = result.Id;
				item.PaymentType = result.PaymentType;
				item.Paid=result.Paid;
				item.Products = new List<GetOrderItemsByIdQueryResult>();
				if (result.OrderItems != null)
				{
					foreach (var products in result.OrderItems)
					{
						GetOrderItemsByIdQueryResult orderitem = new GetOrderItemsByIdQueryResult();
						orderitem.Id = products.Id;
						orderitem.MenuItemId = products.MenuItemId;
						orderitem.MenuItemName = products.MenuItems.Name;
						orderitem.OrdersId = products.OrdersId;
						orderitem.Price = products.Price;
						orderitem.Quantity = products.Quantity;
						item.Products.Add(orderitem);
					}
				}
			}
			return item;
		}

	}
}
