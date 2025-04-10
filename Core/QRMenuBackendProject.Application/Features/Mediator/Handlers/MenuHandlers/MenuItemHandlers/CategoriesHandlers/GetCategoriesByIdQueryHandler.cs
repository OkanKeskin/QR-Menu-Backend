using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Queries.MenuQueries.MenuItemQueries.CategoriesQueries;
using QRMenuBackendProject.Application.Features.Mediator.Results.MenuResults.MenuItemResults;
using QRMenuBackendProject.Application.Features.Mediator.Results.MenuResults.MenuItemResults.CategoriesResults;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Application.Interfaces.CategoriesInterface;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.MenuHandlers.MenuItemHandlers.CategoriesHandlers
{
	public class GetCategoriesByIdQueryHandler : IRequestHandler<GetCategoriesByIdQuery, GetCategoriesByIdQueryResult>
	{
		private readonly IRepository<Categories> _repository;
		private readonly IRepository<MenuItem> _repositoryMenuItem;
		private readonly ICategoriesRepository _repositoryCategories;
		public GetCategoriesByIdQueryHandler(IRepository<Categories> repository, IRepository<MenuItem> repositoryMenuItem, ICategoriesRepository repositoryCategories)
		{
			_repository = repository;
			_repositoryMenuItem = repositoryMenuItem;
			_repositoryCategories = repositoryCategories;
		}

		public async Task<GetCategoriesByIdQueryResult> Handle(GetCategoriesByIdQuery request, CancellationToken cancellationToken)
		{
			List<GetMenuItemQueryResult> menuItemList = new List<GetMenuItemQueryResult>();
			GetMenuItemQueryResult menuItem = new GetMenuItemQueryResult();
			var result = await _repositoryCategories.FindCategories(request.Id);
			var resultList = await _repositoryMenuItem.GetAllAsync() != null ? await _repositoryMenuItem.GetAllAsync() : new List<MenuItem>();
			if (resultList != null)
			{
				resultList = resultList.Where(x => x.CategoriesId == result.Id).ToList();
				foreach (var item in resultList)
				{
					menuItem = new GetMenuItemQueryResult();
					menuItem.Id = item.Id;
					menuItem.Name = item.Name;
					menuItem.Description = item.Description;
					menuItem.CategoriesId = item.CategoriesId;
					menuItem.ContentType = item.ContentType;
					menuItem.Price = item.Price;
					menuItem.MenuId = item.MenuId;
					menuItemList.Add(menuItem);
				}
			}
			return new GetCategoriesByIdQueryResult
			{
				Id = result.Id,
				CategoryName = result.CategoryName,
				MenuId = result.MenuId,
				MenuName = result.Menu.Name,
				Items = menuItemList.Select(x => new GetMenuItemQueryResult
				{
					Id = x.Id,
					Name = x.Name,
					Description = x.Description,
					CategoriesId = x.CategoriesId,
					ContentType = x.ContentType,
					Price = x.Price,
					MenuId = x.MenuId,
				}).ToList(),
			};
		}
	}
}
