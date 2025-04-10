using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using QRMenuBackendProject.Application.Features.Mediator.Commands.RestaurantCommands.RestaurantEmployeeCommands;
using QRMenuBackendProject.Application.Features.Mediator.Queries.RestaurantQueries;
using QRMenuBackendProject.Application.Features.Mediator.Queries.RestaurantQueries.RestaurantEmployeeQueries;

namespace QRMenuBackendProject.WebApi.Controllers.Restaurant
{
    [Route("api/restaurant/{restaurantId}/employee")]
    [ApiController]
    public class RestaurantEmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RestaurantEmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> RestaurantEmployeeList([BindRequired] Guid restaurantId) 
        {
            var values = await _mediator.Send(new GetRestaurantEmployeeQuery(restaurantId));
            return Ok(values);
        }

        [HttpGet("{restaurantEmployeeId}")]
        public async Task<IActionResult> GetRestaurantEmployee([BindRequired] Guid restaurantEmployeeId)
        {
            var values = await _mediator.Send(new GetRestaurantEmployeeByIdQuery(restaurantEmployeeId));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurantEmployee(CreateRestaurantEmployeeCommands command)
        {
            await _mediator.Send(command);
            return Ok("Restorant Çalışanı Başarıyla Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveRestaurantEmployee([BindRequired] Guid id)
        {
            await _mediator.Send(new RemoveRestaurantEmployeeCommands(id));
            return Ok("Restorant Çalışanı Başarıyla Kaldırıldı");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRetaurantEmployee(UpdateRestaurantEmployeeCommands commad)
        {
            await _mediator.Send(commad);
            return Ok("Restorant Çalışanı Başarı İle Güncellendi");
        }
    }
}
