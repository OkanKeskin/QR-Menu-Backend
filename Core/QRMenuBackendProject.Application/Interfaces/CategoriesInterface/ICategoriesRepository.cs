using QRMenuBackendProject.Application.Features.Mediator.Results.MenuResults.MenuItemResults.CategoriesResults;
using QRMenuBackendProject.Domain.Entities;

namespace QRMenuBackendProject.Application.Interfaces.CategoriesInterface
{
	public interface ICategoriesRepository : IRepository<Categories>
	{
		Task<List<Categories>> ListAllCategories();
		Task<Categories> FindCategories(Guid id);
		Task<List<Categories>> ListCategoriesByMenuId(Guid menuId);
	}
}
