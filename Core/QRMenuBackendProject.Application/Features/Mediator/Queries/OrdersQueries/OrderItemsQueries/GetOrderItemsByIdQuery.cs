using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Results.OrdersResults;
using QRMenuBackendProject.Application.Features.Mediator.Results.OrdersResults.OrderItemsResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Queries.OrdersQueries.OrderItemsQueries
{
	public class GetOrderItemsByIdQuery : IRequest<GetOrderItemsByIdQueryResult>
	{
		public Guid Id { get; set; }

		public GetOrderItemsByIdQuery(Guid id)
		{
			Id = id;
		}
	}
}
