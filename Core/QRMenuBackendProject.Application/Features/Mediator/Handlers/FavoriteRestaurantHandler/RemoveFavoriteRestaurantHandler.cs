using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Commands.FavoriteRestaurantCommands;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Domain.Entities;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.FavoriteRestaurantHandler
{
	public class RemoveFavoriteRestaurantHandler : IRequestHandler<RemoveFavoriteRestaurantCommand>
	{
		private readonly IRepository<FavoriteRestaurant> _repository;

		public RemoveFavoriteRestaurantHandler(IRepository<FavoriteRestaurant> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveFavoriteRestaurantCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}
