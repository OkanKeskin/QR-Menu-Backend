using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Interfaces.MenuInterface.MenuItemsInterface
{
	public interface IMenuItemsRepository : IRepository<MenuItem>
	{
		Task<List<MenuItem>> ListAllMenuItemss();
		Task<MenuItem> FindMenuItem(Guid id);
	}
}
