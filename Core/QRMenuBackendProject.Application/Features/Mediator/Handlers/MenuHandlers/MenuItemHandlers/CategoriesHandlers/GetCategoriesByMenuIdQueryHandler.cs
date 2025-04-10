using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Queries.MenuQueries.MenuItemQueries.CategoriesQueries;
using QRMenuBackendProject.Application.Features.Mediator.Results.MenuResults.MenuItemResults.CategoriesResults;
using QRMenuBackendProject.Application.Features.Mediator.Results.MenuResults.MenuItemResults;
using QRMenuBackendProject.Application.Interfaces.CategoriesInterface;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRMenuBackendProject.Application.Interfaces.MenuInterface.MenuItemsInterface;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.MenuHandlers.MenuItemHandlers.CategoriesHandlers
{
	public class GetCategoriesByMenuIdQueryHandler : IRequestHandler<GetCategoriesByMenuIdQuery, List<GetCategoriesQueryResult>>
	{
		private readonly IMenuItemsRepository _repositoryMenuItem;
		private readonly ICategoriesRepository _repositoryCategories;

		public GetCategoriesByMenuIdQueryHandler(IMenuItemsRepository repositoryMenuItem, ICategoriesRepository repositoryCategories)
		{
			_repositoryMenuItem = repositoryMenuItem;
			_repositoryCategories = repositoryCategories;
		}

		public async Task<List<GetCategoriesQueryResult>> Handle(GetCategoriesByMenuIdQuery request, CancellationToken cancellationToken)
		{
			List<GetCategoriesQueryResult> list = new List<GetCategoriesQueryResult>();
			GetCategoriesQueryResult item = new GetCategoriesQueryResult();
			List<GetMenuItemQueryResult> menuItemList = new List<GetMenuItemQueryResult>();
			GetMenuItemQueryResult menuItem = new GetMenuItemQueryResult();
			var values = await _repositoryCategories.ListCategoriesByMenuId(request.MenuId);
			var resultList = await _repositoryMenuItem.ListAllMenuItemss() != null ? await _repositoryMenuItem.ListAllMenuItemss() : new List<MenuItem>();
			if (resultList != null)
			{
				foreach (var result in resultList)
				{
					menuItem = new GetMenuItemQueryResult();
					menuItem.Id = result.Id;
					menuItem.Name = result.Name;
					menuItem.Description = result.Description;
					menuItem.CategoriesId = result.CategoriesId;
					menuItem.CatName = result.Categories.CategoryName;
					menuItem.Price = result.Price;
					menuItem.MenuId = result.MenuId;
					menuItem.ContentType = result.ContentType;
					menuItemList.Add(menuItem);
				}
			}
			foreach (var value in values)
			{
				item = new GetCategoriesQueryResult();
				item.Items = new List<GetMenuItemQueryResult>();
				item.Id = value.Id;
				item.CategoryName = value.CategoryName;
				item.MenuId = value.MenuId;
				item.MenuName = value.Menu.Name;
				item.Items.AddRange(menuItemList.Where(x => x.CategoriesId == value.Id).ToList());
				list.Add(item);
			}
			return list;
		}
	}
}
