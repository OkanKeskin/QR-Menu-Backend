using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using QRMenuBackendProject.Application.Features.Mediator.Commands.OrdersCommands.OrderItemsCommands;
using QRMenuBackendProject.Application.Features.Mediator.Queries.OrdersQueries.OrderItemsQueries;

namespace QRMenuBackendProject.WebApi.Controllers.Orders.OrderItems
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderItemsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public OrderItemsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> CreateOrderItems(CreateOrderItemsCommand command)
		{
			await _mediator.Send(command);
			return Ok("Sipariş Detayı Başarılı Bir Şekilde Oluşturuldu");
		}
		[HttpGet]
		public async Task<IActionResult> OrderItemsList()
		{
			var values = await _mediator.Send(new GetOrderItemsQuery());
			return Ok(values);
		}

		[HttpGet("{orderItemsId}")]
		public async Task<IActionResult> GetOrderItemsById([BindRequired] Guid orderItemsId)
		{
			var values = await _mediator.Send(new GetOrderItemsByIdQuery(orderItemsId));
			if (values.Id != Guid.Empty)
			{
				return Ok(values);
			}
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveOrderItems([BindRequired] Guid id)
		{
			await _mediator.Send(new RemoveOrderItemsCommand(id));
			return Ok("Sipariş Detayı Başarıyla silindi");
		}
	}
}
