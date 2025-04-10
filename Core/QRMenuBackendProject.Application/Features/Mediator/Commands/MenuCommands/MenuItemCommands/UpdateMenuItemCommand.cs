using MediatR;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Commands.MenuCommands.MenuItemCommands
{
	public class UpdateMenuItemCommand : IRequest
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Price { get; set; }
		public Guid MenuId { get; set; }
		public Guid CategoriesId { get; set; }
		public string ContentType { get; set; } //fotoğrafın eklendiği klasör
	}
}
