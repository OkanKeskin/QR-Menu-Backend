using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Queries.OrdersQuries;
using QRMenuBackendProject.Application.Features.Mediator.Results.OrdersResults;
using QRMenuBackendProject.Application.Features.Mediator.Results.OrdersResults.OrderItemsResults;
using QRMenuBackendProject.Application.Interfaces.OrdersInterface;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.OrdersHandler
{
	public class GetAllOrdersHandler : IRequestHandler<GetOrdersQuery, List<GetOrdersQueryResult>>
	{
		private readonly IOrdersRepository _repository;

		public GetAllOrdersHandler(IOrdersRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetOrdersQueryResult>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.ListAllOrders();
			List<GetOrdersQueryResult> result = new List<GetOrdersQueryResult>();
			if(values != null)
			{
				foreach (var value in values)
				{
					GetOrdersQueryResult item = new GetOrdersQueryResult();
					item.Id = value.Id;
					item.PaymentType = value.PaymentType;
					item.Paid = value.Paid;
					item.Products = new List<GetOrderItemsQueryResult>();
					if (value.OrderItems != null)
					{
						foreach (var products in value.OrderItems)
						{
							GetOrderItemsQueryResult orderitem = new GetOrderItemsQueryResult();
							orderitem.Id = products.Id;
							orderitem.MenuItemId = products.MenuItemId;
							orderitem.MenuItemName = products.MenuItems.Name;
							orderitem.OrdersId = products.OrdersId;
							orderitem.Price = products.Price;
							orderitem.Quantity = products.Quantity;
							item.Products.Add(orderitem);
						}
					}
					result.Add(item);
				}
			}
			return result;
		}
	}
}
