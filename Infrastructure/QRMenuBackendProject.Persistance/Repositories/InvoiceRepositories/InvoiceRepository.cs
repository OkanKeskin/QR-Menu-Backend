using Microsoft.EntityFrameworkCore;
using QRMenuBackendProject.Application.Features.Mediator.Results.InvoiceResults;
using QRMenuBackendProject.Application.Interfaces.InvoiceInterface;
using QRMenuBackendProject.Domain.Entities;
using QRMenuBackendProject.Persistance.Context;

namespace QRMenuBackendProject.Persistance.Repositories.InvoiceRepositories
{
	public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
	{
		public InvoiceRepository(QRMenuBackendProjectContext context) : base(context)
		{ }

		public async Task CreateInvoice(Invoice dto)
		{
			_context.Set<Invoice>().Add(dto);
			await _context.SaveChangesAsync();
		}
		public async Task UpdateInvoice(Invoice dto)
		{
			_context.Set<Invoice>().Update(dto);
			await _context.SaveChangesAsync();
		}
		public async Task<List<GetInvoiceQueryResult>> ListAllInvoice()
		{
			return await _context.Set<GetInvoiceQueryResult>().ToListAsync();
		}

		public async Task<GetInvoiceByIdQueryResult> FindInvoice(Guid id)
		{
			var values = await _context.Set<GetInvoiceByIdQueryResult>().FindAsync(id);
			return values;
		}
	}
}
