using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using QRMenuBackendProject.Application.Features.Mediator.Commands.RestaurantCommands;
using QRMenuBackendProject.Application.Features.Mediator.Queries.RestaurantQueries;
using System.Diagnostics;

namespace QRMenuBackendProject.WebApi.Controllers.Restaurant
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RestaurantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> RestaurantList()
        {
            var values = await _mediator.Send(new GetRestaurantQuery());
            return Ok(values);
        }
		[HttpGet("by-user/{userId}", Name = "RestaurantListByUserId")]
		public async Task<IActionResult> RestaurantListByUserId([BindRequired] Guid userId)
		{
			var values = await _mediator.Send(new GetRestaurantByUserIdQuery(userId));
			return Ok(values);
		}

		[HttpGet("{restaurantId}", Name = "GetRestaurantById")]
		public async Task<IActionResult> GetRestaurant([BindRequired] Guid restaurantId)
        {
            var values = await _mediator.Send(new GetRestaurantByIdQuery(restaurantId));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant(CreateRestaurantCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveRestaurant([BindRequired] Guid id)
        {
            await _mediator.Send(new RemoveRestaurantCommand(id));
            return Ok("Restaurant Başarıyla silindi");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurant(UpdateRestaurantCommand command)
        {
            await _mediator.Send(command);
            return Ok("Restaurant Başarıyla Güncellendi");
        }
    }
}