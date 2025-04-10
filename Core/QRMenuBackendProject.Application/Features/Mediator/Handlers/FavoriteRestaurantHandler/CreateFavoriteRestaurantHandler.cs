using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Commands.FavoriteRestaurantCommands;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Domain.Entities;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.FavoriteRestaurantHandler
{
	public class CreateFavoriteRestaurantHandler : IRequestHandler<CreateFavoriteRestaurantCommand>
	{
		private readonly IRepository<FavoriteRestaurant> _repository;

		public CreateFavoriteRestaurantHandler(IRepository<FavoriteRestaurant> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateFavoriteRestaurantCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new FavoriteRestaurant
			{
				CustomerId = request.CustomerId,
				RestaurantId = request.RestaurantId,
				CreatedAt= DateTime.UtcNow,
			});
		}
	}
}
