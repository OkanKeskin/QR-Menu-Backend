using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Results.MenuResults.MenuItemResults.CategoriesResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Queries.MenuQueries.MenuItemQueries.CategoriesQueries
{
	public class GetCategoriesByMenuIdQuery : IRequest<List<GetCategoriesQueryResult>>
	{
		public Guid MenuId { get; set; }

		public GetCategoriesByMenuIdQuery(Guid menuId)
		{
			MenuId = menuId;
		}
	}
}
