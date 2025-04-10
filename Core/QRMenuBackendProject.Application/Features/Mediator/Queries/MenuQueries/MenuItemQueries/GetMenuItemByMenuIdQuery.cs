using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Results.MenuResults.MenuItemResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Queries.MenuQueries.MenuItemQueries
{
    public class GetMenuItemByMenuIdQuery : IRequest<List<GetMenuItemByMenuIdQueryResult>>
    {
        public Guid MenuId { get; set; }

        public GetMenuItemByMenuIdQuery(Guid menuId)
        {
            MenuId = menuId;
        }
    }
}
