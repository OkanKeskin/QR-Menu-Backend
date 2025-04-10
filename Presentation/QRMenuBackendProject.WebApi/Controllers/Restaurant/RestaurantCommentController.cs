using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using QRMenuBackendProject.Application.Features.Mediator.Commands.RestaurantCommands.RestaurantCommentCommands;
using QRMenuBackendProject.Application.Features.Mediator.Commands.RestaurantCommands.RestaurantTableCommands;
using QRMenuBackendProject.Application.Features.Mediator.Queries.RestaurantQueries.RestaurantCommentQueries;

namespace QRMenuBackendProject.WebApi.Controllers.Restaurant
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantCommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RestaurantCommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("restaurant/{restaurantId}")]
        public async Task<IActionResult> GetRestaurantCommentById([BindRequired] Guid restaurantId) 
        {
            var values = await _mediator.Send(new GetRestaurantCommentByRestaurantIdQuery(restaurantId));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurantComment(CreateRestaurantCommentCommands command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            await _mediator.Send(command);
            return Ok("Başarı ile eklendi");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurantComment(UpdateRestaurantCommentCommands commad)
        {
            await _mediator.Send(commad);
            return Ok("Restorant Yorumu Başarı İle Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveRestaurantComment([BindRequired] Guid id)
        {
            await _mediator.Send(new RemoveRestaurantCommentCommands(id));
            return Ok("Restorant Yorumu Başarıyla Kaldırıldı");
        }
    }
}
