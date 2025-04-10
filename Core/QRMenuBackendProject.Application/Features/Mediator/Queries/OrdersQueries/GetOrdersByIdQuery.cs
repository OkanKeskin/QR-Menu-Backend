using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Results.OrdersResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Queries.OrdersQuries
{
	public class GetOrdersByIdQuery : IRequest<GetOrdersByIdQueryResult>
	{
		public Guid Id { get; set; }

		public GetOrdersByIdQuery(Guid id)
		{
			Id = id;
		}

	}
}
