using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using QRMenuBackendProject.Application.Features.Mediator.Commands.MenuCommands;
using QRMenuBackendProject.Application.Features.Mediator.Queries.MenuQueries;

namespace QRMenuBackendProject.WebApi.Controllers.Restaurant.Menu
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MenuController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> MenuList()
        {
            var values = await _mediator.Send(new GetMenuQuery());
            return Ok(values);
        }

        [HttpGet("{menuId}")]
        public async Task<IActionResult> GetMenu([BindRequired] Guid menuId)
        {
            var values = await _mediator.Send(new GetMenuByIdQuery(menuId));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu(CreateMenuCommand command)
        {
            await _mediator.Send(command);
            return Ok("Menu Başarıyla Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveMenu([BindRequired] Guid id)
        {
            await _mediator.Send(new RemoveMenuCommand(id));
            return Ok("Menu Başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMenu(UpdateMenuCommand command)
        {
            await _mediator.Send(command);
            return Ok("Menu Başarıyla Güncellendi");
        }
    }
}
