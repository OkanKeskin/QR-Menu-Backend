using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Commands.MenuCommands.MenuItemCommands
{
	public class RemoveMenuItemCommand : IRequest
	{
		public RemoveMenuItemCommand(Guid id)
		{
			Id = id;
		}
		public Guid Id { get; set; }
	}
}
