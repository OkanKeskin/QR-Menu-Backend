using QRMenuBackendProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Results.InvoiceResults
{
	public class GetInvoiceByIdQueryResult
	{
        public Guid Id { get; set; }
        public DateTime ProccesDate { get; set; }
		public decimal Total { get; set; }
		public PaymentType PaymentType { get; set; }
	}
}
