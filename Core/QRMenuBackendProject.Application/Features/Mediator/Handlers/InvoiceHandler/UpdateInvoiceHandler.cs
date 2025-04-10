using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Commands.InvoiceCommands;
using QRMenuBackendProject.Application.Interfaces.InvoiceInterface;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.InvoiceHandler
{
	public class UpdateInvoiceHandler : IRequestHandler<UpdateInvoiceCommand>
	{
		private readonly IInvoiceRepository _repository;

		public UpdateInvoiceHandler(IInvoiceRepository repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
		{
			await _repository.UpdateInvoice(new Invoice
			{
				ProccesDate = request.ProccesDate,
				Total = request.Total,
			});
		}
	}
}
