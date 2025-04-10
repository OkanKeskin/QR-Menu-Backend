using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using QRMenuBackendProject.Application.Features.Mediator.Commands.MenuCommands.MenuItemCommands.CategoriesCommands;
using QRMenuBackendProject.Application.Features.Mediator.Queries.MenuQueries.MenuItemQueries.CategoriesQueries;
using QRMenuBackendProject.Domain.Entities;
using System;

namespace QRMenuBackendProject.WebApi.Controllers.Restaurant.Menu
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CategoriesList()
        {
            var values = await _mediator.Send(new GetCategoriesQuery());
            return Ok(values);
        }

		[HttpGet("menu/{menuId}")] 
		public async Task<IActionResult> CategoriesListByMenuId([BindRequired] Guid menuId)
		{
			var values = await _mediator.Send(new GetCategoriesByMenuIdQuery(menuId));
			return Ok(values);
		}

		[HttpGet("{categoryId}")] 
		public async Task<IActionResult> GetCategory([BindRequired] Guid categoryId)
		{
			var value = await _mediator.Send(new GetCategoriesByIdQuery(categoryId));
			return Ok(value);
		}

		[HttpPost]
        public async Task<IActionResult> CreateCategories(CreateCategoriesCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kategori Başarıyla Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategories([BindRequired] Guid id)
        {
            await _mediator.Send(new RemoveCategoriesCommand(id));
            return Ok("Kategori Başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategories(UpdateCategoriesCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kategori Başarıyla Güncellendi");
        }
    }
}
