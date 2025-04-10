using MediatR;
using QRMenuBackendProject.Domain.Enums;

namespace QRMenuBackendProject.Application.Features.Mediator.Commands.InvoiceCommands
{
	public class CreateInvoiceCommand : IRequest
	{
        public Guid OrdersId { get; set; }
        public DateTime ProccesDate { get; set; }
		public double Total { get; set; }
	}	
}
