using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Commands.MenuCommands.MenuItemCommands.CategoriesCommands
{
    public class CreateCategoriesCommand : IRequest
    {
        public string CategoryName { get; set; }
        public Guid MenuId { get; set; }
    }
}
