using QRMenuBackendProject.Application.Features.Mediator.Results.InvoiceResults;
using QRMenuBackendProject.Domain.Entities;

namespace QRMenuBackendProject.Application.Interfaces.InvoiceInterface
{
	public interface IInvoiceRepository : IRepository<Invoice>
	{
		Task CreateInvoice(Invoice dto);
		Task UpdateInvoice(Invoice dto);
		Task<List<GetInvoiceQueryResult>> ListAllInvoice();
		Task<GetInvoiceByIdQueryResult> FindInvoice(Guid id);
	}
}
