using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Commands.InvoiceCommands;
using QRMenuBackendProject.Application.Interfaces.InvoiceInterface;
using QRMenuBackendProject.Application.Interfaces.OrdersInterface;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.InvoiceHandler
{
	public class CreateInvoiceHandler : IRequestHandler<CreateInvoiceCommand>
	{
		private readonly IInvoiceRepository _repository;

		public CreateInvoiceHandler(IInvoiceRepository repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateInvoice(new Invoice
			{
				OrdersId= request.OrdersId,
				ProccesDate = request.ProccesDate,
				Total = request.Total,
			});
		}
	}
}
