using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using QRMenuBackendProject.Application.Features.Mediator.Commands.FavoriteRestaurantCommands;
using QRMenuBackendProject.Application.Features.Mediator.Queries.FavoriteRestaurantsQueries;

namespace QRMenuBackendProject.WebApi.Controllers.Restaurant.FavoriteRestaurant
{
		[Route("api/[controller]")]
		[ApiController]
		public class FavoriteRestaurantController : ControllerBase
		{
			private readonly IMediator _mediator;

			public FavoriteRestaurantController(IMediator mediator)
			{
				_mediator = mediator;
			}
			[HttpPost]
			public async Task<IActionResult> CreateFavoriteRestaurant(CreateFavoriteRestaurantCommand command)
			{
				await _mediator.Send(command);
				return Ok("Restaurant Favoriye Başarıyla Eklendi");
			}
			[HttpGet("{customerId}")]
			public async Task<IActionResult> GetRestaurant([BindRequired] Guid customerId)
			{
				var values = await _mediator.Send(new GetFavoriteRestaurantQuery(customerId));
				return Ok(values);
			}
			[HttpDelete("{id}")]
			public async Task<IActionResult> RemoveRestaurant([BindRequired] Guid id)
			{
				await _mediator.Send(new RemoveFavoriteRestaurantCommand(id));
				return Ok("Restaurant Favoriden Başarıyla silindi");
			}
		}
}
