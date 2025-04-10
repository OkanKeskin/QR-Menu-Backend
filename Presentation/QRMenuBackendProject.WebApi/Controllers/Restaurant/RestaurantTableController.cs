using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using QRMenuBackendProject.Application.Features.Mediator.Commands.RestaurantCommands.RestaurantEmployeeCommands;
using QRMenuBackendProject.Application.Features.Mediator.Commands.RestaurantCommands.RestaurantTableCommands;
using QRMenuBackendProject.Application.Features.Mediator.Queries.RestaurantQueries.RestaurantEmployeeQueries;
using QRMenuBackendProject.Application.Features.Mediator.Queries.RestaurantQueries.RestaurantTableQueries;
using QRMenuBackendProject.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QRMenuBackendProject.WebApi.Controllers.Restaurant
{
    [Route("api/restaurant/table")]
    [ApiController]
    public class RestaurantTableController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RestaurantTableController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> RestaurantTableList()
        {
            var values = await _mediator.Send(new GetRestaurantTableQuery());
            return Ok(values);
        }

        [HttpGet("{restaurantTableId}")]
        public async Task<IActionResult> GetRestaurantTable(Guid restaurantTableId)
        {
            var values = await _mediator.Send(new GetRestaurantTableByIdQuery(restaurantTableId));
            return Ok(values);
        }

        [HttpGet("restaurant/{restaurantId}")]
        public async Task<IActionResult> GetRestaurantTableListByRestaurantId(Guid restaurantId)
        {
            var values = await _mediator.Send(new GetRestaurantTableQuery());
            var list = values.Where(rt => rt.RestaurantId == restaurantId).OrderBy(rt=>rt.TableNo);
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurantTable(CreateRestaurantTableCommand command)
        {
            await _mediator.Send(command);
            return Ok("Restorant Masası Başarıyla Eklendi");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRetaurantTable(UpdateRestaurantTableCommand commad)
        {
            await _mediator.Send(commad);
            return Ok("Restorant Masası Başarı İle Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveRestaurantTable([BindRequired] Guid id)
        {
            await _mediator.Send(new RemoveRestaurantTableCommand(id));
            return Ok("Restorant Masası Başarıyla Kaldırıldı");
        }
    }
}
