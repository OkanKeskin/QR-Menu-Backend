using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using QRMenuBackendProject.Application.Features.Mediator.Commands.MenuCommands.MenuItemCommands;
using QRMenuBackendProject.Application.Features.Mediator.Queries.MenuQueries.MenuItemQueries;

namespace QRMenuBackendProject.WebApi.Controllers.Restaurant.Menu
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MenuItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> MenuItemList()
        {
            var values = await _mediator.Send(new GetMenuItemQuery());
            return Ok(values);
        }

        [HttpGet("{menuItemId}")]
        public async Task<IActionResult> GetMenuItem([BindRequired] Guid menuItemId)
        {
            var values = await _mediator.Send(new GetMenuItemByIdQuery(menuItemId));
            return Ok(values);
        }

        [HttpGet("{menuId}")]
        public async Task<IActionResult> GetMenuItemByMenuId([BindRequired] Guid menuId)
        {
            var values = await _mediator.Send(new GetMenuItemByMenuIdQuery(menuId));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenuItem(CreateMenuItemCommand command)
        {
            await _mediator.Send(command);
            return Ok("Menu öğesi Başarıyla Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveMenuItem([BindRequired] Guid id)
        {
            await _mediator.Send(new RemoveMenuItemCommand(id));
            return Ok("Menu öğesi Başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMenuItem(UpdateMenuItemCommand command)
        {
            await _mediator.Send(command);
            return Ok("Menu öğesi Başarıyla Güncellendi");
        }
    }
}
