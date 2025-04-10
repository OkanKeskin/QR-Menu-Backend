using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Queries.InvoiceQueries;
using QRMenuBackendProject.Application.Features.Mediator.Results.InvoiceResults;
using QRMenuBackendProject.Application.Interfaces.InvoiceInterface;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.InvoiceHandler
{
	public class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, GetInvoiceByIdQueryResult>
	{
		private readonly IInvoiceRepository _repository;

		public GetInvoiceByIdQueryHandler(IInvoiceRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetInvoiceByIdQueryResult> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
		{
			var result = await _repository.FindInvoice(request.Id);
			return new GetInvoiceByIdQueryResult
			{
				Id = result.Id,
				ProccesDate = result.ProccesDate,
				Total = result.Total,
				PaymentType= result.PaymentType,
			};
		}
	}
}
