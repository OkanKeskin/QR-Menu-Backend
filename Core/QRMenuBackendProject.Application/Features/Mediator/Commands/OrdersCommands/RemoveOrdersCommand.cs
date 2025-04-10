using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Commands.OrdersCommands
{
	public class RemoveOrdersCommand : IRequest
	{
		public RemoveOrdersCommand(Guid id)
		{
			Id = id;
		}
		public Guid Id { get; set; }

	}
}
