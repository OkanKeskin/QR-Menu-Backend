using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Commands.InvoiceCommands;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Domain.Entities;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.InvoiceHandler
{
	public class RemoveInvoiceHandler : IRequestHandler<RemoveInvoiceCommand>
	{
		private readonly IRepository<Invoice> _repository;

		public RemoveInvoiceHandler(IRepository<Invoice> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveInvoiceCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}
