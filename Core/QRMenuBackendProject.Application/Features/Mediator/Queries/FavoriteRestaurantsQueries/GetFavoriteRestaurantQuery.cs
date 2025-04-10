using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Results.FavoriteRestaurantResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Queries.FavoriteRestaurantsQueries
{
	public class GetFavoriteRestaurantQuery : IRequest<List<GetFavoriteRestaurantResult>>
	{
		public Guid CustomerId { get; set; }

		public GetFavoriteRestaurantQuery(Guid customerId)
		{
			CustomerId = customerId;
		}
	}
}
