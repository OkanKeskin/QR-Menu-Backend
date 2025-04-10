using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Results.RestaurantResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Queries.RestaurantQueries
{
	public class GetRestaurantByUserIdQuery : IRequest<List<GetRestaurantByUserIdQueryResult>>
	{
		public Guid UserId { get; set; }

		public GetRestaurantByUserIdQuery(Guid userid)
		{
			UserId = userid;
		}
	}
}
