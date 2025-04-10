using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Results.InvoiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Queries.InvoiceQueries
{
	public class GetInvoiceByIdQuery : IRequest<GetInvoiceByIdQueryResult>
	{
		public Guid Id { get; set; }

		public GetInvoiceByIdQuery(Guid id)
		{
			Id = id;
		}
	}
}
