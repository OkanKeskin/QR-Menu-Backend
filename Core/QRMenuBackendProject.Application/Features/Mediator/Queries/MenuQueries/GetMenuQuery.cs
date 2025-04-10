using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Results.MenuResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Queries.MenuQueries
{
	public class GetMenuQuery : IRequest<List<GetMenuQueryResult>>
	{
	}
}
