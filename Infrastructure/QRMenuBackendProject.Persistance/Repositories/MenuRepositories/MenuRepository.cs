using Microsoft.EntityFrameworkCore;
using QRMenuBackendProject.Application.Features.Mediator.Commands.MenuCommands;
using QRMenuBackendProject.Application.Features.Mediator.Commands.OrdersCommands;
using QRMenuBackendProject.Application.Interfaces.MenuInterface;
using QRMenuBackendProject.Domain.Entities;
using QRMenuBackendProject.Persistance.Context;

namespace QRMenuBackendProject.Persistance.Repositories.MenuRepositories
{
	public class MenuRepository : Repository<Menu>, IMenuRepository
	{
		public MenuRepository(QRMenuBackendProjectContext context) : base(context)
		{ }
		
		public async Task<List<Menu>> ListAllMenus()
		{
			return await _context.Set<Menu>().Include(x => x.MenuItems).ThenInclude(x => x.Categories).ToListAsync();
		}

		public async Task<Menu> FindMenu(Guid id)
		{
			return await _context.Set<Menu>().Include(x => x.MenuItems).ThenInclude(x => x.Categories).FirstOrDefaultAsync(x => x.Id == id);
		}

	}
}
