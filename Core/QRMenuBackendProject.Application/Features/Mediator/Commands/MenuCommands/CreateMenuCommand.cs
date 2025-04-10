using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Commands.MenuCommands
{
	public class CreateMenuCommand : IRequest
	{
		public string Name { get; set; }
		public Guid RestaurantId { get; set; }
	}
}
