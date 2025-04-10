using Microsoft.EntityFrameworkCore;
using QRMenuBackendProject.Application.Interfaces.MenuInterface;
using QRMenuBackendProject.Application.Interfaces.MenuInterface.MenuItemsInterface;
using QRMenuBackendProject.Domain.Entities;
using QRMenuBackendProject.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Persistance.Repositories.MenuRepositories.MenuItemsRepositories
{
	public class MenuItemRepository : Repository<MenuItem>, IMenuItemsRepository
	{
		public MenuItemRepository(QRMenuBackendProjectContext context) : base(context)
		{ }

		public async Task<MenuItem> FindMenuItem(Guid id)
		{
			return await _context.Set<MenuItem>().Include(x => x.Categories).FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<List<MenuItem>> ListAllMenuItemss()
		{
			return await _context.Set<MenuItem>().Include(x => x.Categories).ToListAsync();
		}
	}
}
