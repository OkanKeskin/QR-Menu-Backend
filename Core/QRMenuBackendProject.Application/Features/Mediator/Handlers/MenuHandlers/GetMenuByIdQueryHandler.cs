using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Queries.MenuQueries;
using QRMenuBackendProject.Application.Features.Mediator.Results.MenuResults;
using QRMenuBackendProject.Application.Features.Mediator.Results.MenuResults.MenuItemResults;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Application.Interfaces.MenuInterface.MenuItemsInterface;
using QRMenuBackendProject.Application.Interfaces.MenuInterface;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.MenuHandlers
{
	public class GetMenuByIdQueryHandler : IRequestHandler<GetMenuByIdQuery, GetMenuByIdQueryResult>
	{
		private readonly IMenuRepository _repository;
		private readonly IMenuItemsRepository _repositoryMenuItem;

		public GetMenuByIdQueryHandler(IMenuRepository repository, IMenuItemsRepository repositoryMenuItem)
		{
			_repository = repository;
			_repositoryMenuItem = repositoryMenuItem;
		}

		public async Task<GetMenuByIdQueryResult> Handle(GetMenuByIdQuery request, CancellationToken cancellationToken)
		{
			List<GetMenuItemQueryResult> menuItemList = new List<GetMenuItemQueryResult>();
			GetMenuItemQueryResult menuItem = new GetMenuItemQueryResult();
			var result = await _repository.FindMenu(request.Id);
			var resultList = await _repositoryMenuItem.ListAllMenuItemss() != null ? await _repositoryMenuItem.GetAllAsync() : new List<MenuItem>();
			if (resultList != null)
			{
				resultList = resultList.Where(x => x.MenuId == result.Id).ToList();
				foreach (var item in resultList)
				{
					menuItem = new GetMenuItemQueryResult();
					menuItem.Id = item.Id;
					menuItem.Name = item.Name;
					menuItem.Description = item.Description;
					menuItem.CategoriesId = item.CategoriesId;
					menuItem.CatName = item.Categories.CategoryName;
					menuItem.Price = item.Price;
					menuItem.MenuId = item.MenuId;
					menuItemList.Add(menuItem);
				}
			}
			return new GetMenuByIdQueryResult
			{
				Id = result.Id,
				Name = result.Name,
				RestaurantId = result.RestaurantId,
				RestaurantName = result.Restaurant != null ? result.Restaurant.Name : "",
				MenuItems=menuItemList.Select(x => new GetMenuItemQueryResult
				{
					Id=x.Id,
					Name=x.Name,
					Description=x.Description,
					CategoriesId=x.CategoriesId,
					CatName=x.CatName,
					Price=x.Price,
					MenuId=x.MenuId,
				}).ToList(),
			};
		}
	}
}
