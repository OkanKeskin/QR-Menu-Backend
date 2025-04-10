using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Queries.MenuQueries.MenuItemQueries;
using QRMenuBackendProject.Application.Features.Mediator.Results.MenuResults.MenuItemResults;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Application.Interfaces.MenuInterface.MenuItemsInterface;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.MenuHandlers.MenuItemHandlers
{
	internal class GetMenuItemByIdQueryHandler : IRequestHandler<GetMenuItemByIdQuery, GetMenuItemByIdQueryResult>
	{
		private readonly IMenuItemsRepository _repositoryMenuItem;

		public GetMenuItemByIdQueryHandler(IMenuItemsRepository repository)
		{
			_repositoryMenuItem = repository;
		}

		public async Task<GetMenuItemByIdQueryResult> Handle(GetMenuItemByIdQuery request, CancellationToken cancellationToken)
		{
			var result = await _repositoryMenuItem.FindMenuItem(request.Id);
			return new GetMenuItemByIdQueryResult
			{
				Id = result.Id,
				Name = result.Name,
				Description = result.Description,
				Price = result.Price,
				MenuId = result.MenuId,
				CategoriesId = result.CategoriesId,
				CatName=result.Categories.CategoryName,
				ContentType = result.ContentType,
			};
		}
	}
}
