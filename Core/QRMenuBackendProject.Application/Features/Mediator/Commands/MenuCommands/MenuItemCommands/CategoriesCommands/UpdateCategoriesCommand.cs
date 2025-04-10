using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Commands.MenuCommands.MenuItemCommands.CategoriesCommands
{
    public class UpdateCategoriesCommand : IRequest
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
		public Guid MenuId { get; set; }
	}
}
