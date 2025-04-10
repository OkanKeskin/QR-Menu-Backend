using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Queries.FavoriteRestaurantsQueries;
using QRMenuBackendProject.Application.Features.Mediator.Results.FavoriteRestaurantResults;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Application.Interfaces.FavoriteRestaurantInterface;
using QRMenuBackendProject.Domain.Entities;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.FavoriteRestaurantHandler
{
	public class GetAllFavoriteRestaurantHandler : IRequestHandler<GetFavoriteRestaurantQuery, List<GetFavoriteRestaurantResult>>
	{
		private readonly IFavoriteRestaurantRepository _repository;

		public GetAllFavoriteRestaurantHandler(IFavoriteRestaurantRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetFavoriteRestaurantResult>> Handle(GetFavoriteRestaurantQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.ListFavoriteRestaurant(request.CustomerId);
			return values.Select(x => new GetFavoriteRestaurantResult
			{
				Id= x.Id,
				CustomerId = x.CustomerId,
				CustomerName = x.Customer.Name,
				RestaurantId = x.RestaurantId,
				RestaurantName = x.Restaurant.Name
			}).ToList();
		}
	}
}
