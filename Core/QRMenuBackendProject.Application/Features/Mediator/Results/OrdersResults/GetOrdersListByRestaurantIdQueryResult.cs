using QRMenuBackendProject.Application.Features.Mediator.Results.OrdersResults.OrderItemsResults;
using QRMenuBackendProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Results.OrdersResults
{
    public class GetOrdersListByRestaurantIdQueryResult
    {
		public Guid Id { get; set; }
		public PaymentType PaymentType { get; set; }
		public List<GetOrderItemsQueryResult> Products { get; set; }
		public bool Paid { get; set; }
	}
}
