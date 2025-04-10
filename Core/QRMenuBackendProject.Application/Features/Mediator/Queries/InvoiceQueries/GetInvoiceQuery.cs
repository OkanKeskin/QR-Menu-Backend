using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Results.InvoiceResults;
using QRMenuBackendProject.Application.Features.Mediator.Results.OrdersResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Queries.InvoiceQueries
{
	public class GetInvoiceQuery : IRequest<List<GetInvoiceQueryResult>>
	{

	}
}
