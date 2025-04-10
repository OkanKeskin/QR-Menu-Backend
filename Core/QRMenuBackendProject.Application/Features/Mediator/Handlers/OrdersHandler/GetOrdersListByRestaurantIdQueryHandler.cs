using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Queries.OrdersQuries;
using QRMenuBackendProject.Application.Features.Mediator.Results.OrdersResults.OrderItemsResults;
using QRMenuBackendProject.Application.Features.Mediator.Results.OrdersResults;
using QRMenuBackendProject.Application.Interfaces.OrdersInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRMenuBackendProject.Application.Features.Mediator.Queries.OrdersQueries;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.OrdersHandler
{
    public class GetOrdersListByRestaurantIdQueryHandler : IRequestHandler<GetOrdersListByRestaurantIdQuery, List<GetOrdersListByRestaurantIdQueryResult>>
	{
		private readonly IOrdersRepository _repository;

		public GetOrdersListByRestaurantIdQueryHandler(IOrdersRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetOrdersListByRestaurantIdQueryResult>> Handle(GetOrdersListByRestaurantIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetListByRestaurantId(request.RestaurantId);
			List<GetOrdersListByRestaurantIdQueryResult> result = new List<GetOrdersListByRestaurantIdQueryResult>();
			if (values != null)
			{
				foreach (var value in values)
				{
					GetOrdersListByRestaurantIdQueryResult item = new GetOrdersListByRestaurantIdQueryResult();
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
