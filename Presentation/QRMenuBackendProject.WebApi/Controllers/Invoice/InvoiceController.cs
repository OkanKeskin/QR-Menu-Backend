using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using QRMenuBackendProject.Application.Features.Mediator.Commands.InvoiceCommands;
using QRMenuBackendProject.Application.Features.Mediator.Queries.InvoiceQueries;

namespace QRMenuBackendProject.WebApi.Controllers.Invoice
{
	[Route("api/[controller]")]
	[ApiController]
	public class InvoiceController : ControllerBase
	{
		private readonly IMediator _mediator;

		public InvoiceController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> CreateInvoice(CreateInvoiceCommand command)
		{
			await _mediator.Send(command);
			return Ok("Fatura Başarılı Bir Şekilde Oluşturuldu");
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateInvoice(UpdateInvoiceCommand command)
		{
			await _mediator.Send(command);
			return Ok("Fatura Başarıyla Güncellendi");
		}
		[HttpGet]
		public async Task<IActionResult> InvoiceList()
		{
			var values = await _mediator.Send(new GetInvoiceQuery());
			return Ok(values);
		}

		[HttpGet("{invoiceId}")]
		public async Task<IActionResult> GetInvoiceById([BindRequired] Guid invoiceId)
		{
			var values = await _mediator.Send(new GetInvoiceByIdQuery(invoiceId));
			return Ok(values);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveInvoice([BindRequired] Guid id)
		{
			await _mediator.Send(new RemoveInvoiceCommand(id));
			return Ok("Fatura Başarıyla silindi");
		}
	}
}
