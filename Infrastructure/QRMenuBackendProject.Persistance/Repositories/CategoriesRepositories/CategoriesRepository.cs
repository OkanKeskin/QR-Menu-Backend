using Microsoft.EntityFrameworkCore;
using QRMenuBackendProject.Application.Features.Mediator.Results.InvoiceResults;
using QRMenuBackendProject.Application.Features.Mediator.Results.MenuResults.MenuItemResults;
using QRMenuBackendProject.Application.Features.Mediator.Results.MenuResults.MenuItemResults.CategoriesResults;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Application.Interfaces.CategoriesInterface;
using QRMenuBackendProject.Application.Interfaces.InvoiceInterface;
using QRMenuBackendProject.Domain.Entities;
using QRMenuBackendProject.Persistance.Context;

namespace QRMenuBackendProject.Persistance.Repositories.CategoriesRepositories
{
	public class CategoriesRepository : Repository<Categories>, ICategoriesRepository
	{
		public CategoriesRepository(QRMenuBackendProjectContext context) : base(context)
		{ }

		public async Task<Categories> FindCategories(Guid id)
		{
			var values = await _context.Set<Categories>().Include(x => x.Menu).ThenInclude(x => x.MenuItems).FirstOrDefaultAsync(x => x.Id == id);
			return values;
		}
		public async Task<List<Categories>> ListCategoriesByMenuId(Guid menuId)
		{
			var values = await _context.Set<Categories>()
										.Include(x => x.Menu).ThenInclude(x => x.MenuItems)
										.Where(c => c.MenuId == menuId)
										.ToListAsync();
			return values;
		}


		public async Task<List<Categories>> ListAllCategories()
		{
			var result = await _context.Set<Categories>().Include(x => x.Menu).ThenInclude(x => x.MenuItems).ToListAsync();
			return result;
		}
	}
}
