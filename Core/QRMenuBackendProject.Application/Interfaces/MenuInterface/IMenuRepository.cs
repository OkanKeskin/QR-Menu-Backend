using QRMenuBackendProject.Application.Features.Mediator.Commands.MenuCommands;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Interfaces.MenuInterface
{
	public interface IMenuRepository : IRepository<Menu>
	{
		Task<List<Menu>> ListAllMenus();
		Task<Menu> FindMenu(Guid id);
	}
}
