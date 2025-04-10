using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Results.MenuResults.MenuItemResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Queries.MenuQueries.MenuItemQueries
{
	public class GetMenuItemByIdQuery : IRequest<GetMenuItemByIdQueryResult>
	{
		public Guid Id { get; set; }

		public GetMenuItemByIdQuery(Guid id)
		{
            Id = id;
		}
	}
}
