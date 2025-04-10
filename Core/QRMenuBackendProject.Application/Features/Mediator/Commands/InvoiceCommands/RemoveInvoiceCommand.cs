using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Commands.InvoiceCommands
{
	public class RemoveInvoiceCommand : IRequest
	{
		public RemoveInvoiceCommand(Guid id)
		{
			Id = id;
		}
		public Guid Id { get; set; }
	}
}
