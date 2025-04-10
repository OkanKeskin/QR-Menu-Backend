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
	public class GetMenuItemQueryHandler : IRequestHandler<GetMenuItemQuery, List<GetMenuItemQueryResult>>
	{
		private readonly IMenuItemsRepository _repositoryMenuItem;

		public GetMenuItemQueryHandler(IMenuItemsRepository repository)
		{
			_repositoryMenuItem = repository;
		}

		public async Task<List<GetMenuItemQueryResult>> Handle(GetMenuItemQuery request, CancellationToken cancellationToken)
		{
			var values = await _repositoryMenuItem.ListAllMenuItemss();
			return values.Select(x => new GetMenuItemQueryResult
			{
				Id = x.Id,
				Name = x.Name,
				Description = x.Description,
				Price = x.Price,
				MenuId = x.MenuId,
				CategoriesId = x.CategoriesId,
				CatName=x.Categories.CategoryName,
				ContentType = x.ContentType,
			}).ToList();
		}
	}
}
