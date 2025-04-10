using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Queries.MenuQueries;
using QRMenuBackendProject.Application.Features.Mediator.Results.MenuResults;
using QRMenuBackendProject.Application.Features.Mediator.Results.MenuResults.MenuItemResults;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Application.Interfaces.MenuInterface;
using QRMenuBackendProject.Application.Interfaces.MenuInterface.MenuItemsInterface;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.MenuHandlers
{
	public class GetMenuQueryHandler : IRequestHandler<GetMenuQuery, List<GetMenuQueryResult>>
	{
		private readonly IMenuRepository _repository;
		private readonly IMenuItemsRepository _repositoryMenuItem;

		public GetMenuQueryHandler(IMenuRepository repository, IMenuItemsRepository repositoryMenuItem)
		{
			_repository = repository;
			_repositoryMenuItem = repositoryMenuItem;
		}

		public async Task<List<GetMenuQueryResult>> Handle(GetMenuQuery request, CancellationToken cancellationToken)
		{
			List<GetMenuQueryResult> list = new List<GetMenuQueryResult>();
			GetMenuQueryResult item = new GetMenuQueryResult();
			List<GetMenuItemQueryResult> menuItemList = new List<GetMenuItemQueryResult>();
			GetMenuItemQueryResult menuItem = new GetMenuItemQueryResult();
			var values = await _repository.ListAllMenus();
			var resultList = await _repositoryMenuItem.ListAllMenuItemss() != null ? await _repositoryMenuItem.GetAllAsync() : new List<MenuItem>();
			if(resultList != null)
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
					menuItemList.Add(menuItem);
				}	
			}
			foreach (var value in values) 
			{
				item = new GetMenuQueryResult();
				item.MenuItems = new List<GetMenuItemQueryResult>();
				item.Id = value.Id;
				item.Name = value.Name;
				item.RestaurantId = value.RestaurantId;
				item.RestaurantName = value.Restaurant != null ? value.Restaurant.Name :  "";
				item.MenuItems.AddRange( menuItemList.Where(x=> x.MenuId==value.Id).ToList());				
				list.Add(item);
			}
			return list;
		}
	}
}
