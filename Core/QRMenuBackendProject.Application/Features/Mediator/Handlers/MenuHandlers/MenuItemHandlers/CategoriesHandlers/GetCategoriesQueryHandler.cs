using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Queries.MenuQueries.MenuItemQueries.CategoriesQueries;
using QRMenuBackendProject.Application.Features.Mediator.Results.MenuResults.MenuItemResults;
using QRMenuBackendProject.Application.Features.Mediator.Results.MenuResults.MenuItemResults.CategoriesResults;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Application.Interfaces.CategoriesInterface;
using QRMenuBackendProject.Domain.Entities;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.MenuHandlers.MenuItemHandlers.CategoriesHandlers
{
	public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<GetCategoriesQueryResult>>
	{
		private readonly IRepository<Categories> _repository;
		private readonly IRepository<MenuItem> _repositoryMenuItem;
		private readonly ICategoriesRepository _repositoryCategories;

		public GetCategoriesQueryHandler(IRepository<Categories> repository, IRepository<MenuItem> repositoryMenuItem, ICategoriesRepository repositoryCategories)
		{
			_repository = repository;
			_repositoryMenuItem = repositoryMenuItem;
			_repositoryCategories = repositoryCategories;
		}

		public async Task<List<GetCategoriesQueryResult>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
		{
			List<GetCategoriesQueryResult> list = new List<GetCategoriesQueryResult>();
			GetCategoriesQueryResult item = new GetCategoriesQueryResult();
			List<GetMenuItemQueryResult> menuItemList = new List<GetMenuItemQueryResult>();
			GetMenuItemQueryResult menuItem = new GetMenuItemQueryResult();
			var values = await _repositoryCategories.ListAllCategories();
			var resultList = await _repositoryMenuItem.GetAllAsync() != null ? await _repositoryMenuItem.GetAllAsync() : new List<MenuItem>();
			if (resultList != null)
			{
				foreach (var result in resultList)
				{
					menuItem = new GetMenuItemQueryResult();
					menuItem.Id = result.Id;
					menuItem.Name = result.Name;
					menuItem.Description = result.Description;
					menuItem.CategoriesId = result.CategoriesId;
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
