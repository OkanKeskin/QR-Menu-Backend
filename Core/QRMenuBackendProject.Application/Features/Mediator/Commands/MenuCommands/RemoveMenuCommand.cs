using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Commands.MenuCommands
{
	public class RemoveMenuCommand : IRequest
	{
		public RemoveMenuCommand(Guid id)
		{
			Id = id;
		}
		public Guid Id { get; set; }
		
	}
}
