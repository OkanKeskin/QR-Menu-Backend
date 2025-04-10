using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Queries.InvoiceQueries;
using QRMenuBackendProject.Application.Features.Mediator.Results.InvoiceResults;
using QRMenuBackendProject.Application.Interfaces.InvoiceInterface;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.InvoiceHandler
{
	public class GetAllInvoiceHandler : IRequestHandler<GetInvoiceQuery, List<GetInvoiceQueryResult>>
	{
		private readonly IInvoiceRepository _repository;

		public GetAllInvoiceHandler(IInvoiceRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetInvoiceQueryResult>> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.ListAllInvoice();
			return values.Select(x => new GetInvoiceQueryResult
			{
				Id = x.Id,
				ProccesDate = x.ProccesDate,
				Total = x.Total,
				PaymentType = x.PaymentType
			}).ToList();
		}
	}
}
