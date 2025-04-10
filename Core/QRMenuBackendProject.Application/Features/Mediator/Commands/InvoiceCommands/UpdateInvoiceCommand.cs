using MediatR;
using QRMenuBackendProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Commands.InvoiceCommands
{
	public class UpdateInvoiceCommand : IRequest
	{
        public Guid Id { get; set; }
        public DateTime ProccesDate { get; set; }
		public double Total { get; set; }
		public PaymentType PaymentType { get; set; }
	}
}
