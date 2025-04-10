using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using QRMenuBackendProject.Application.Features.Mediator.Commands.OrdersCommands;
using QRMenuBackendProject.Application.Features.Mediator.Queries.OrdersQuries;
using QRMenuBackendProject.Application.Interfaces.OrdersInterface;
using QRMenuBackendProject.Domain.Entities;
using QRMenuBackendProject.Application.Features.Mediator.Queries.OrdersQueries;

namespace QRMenuBackendProject.WebApi.Controllers.Orders
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IOrdersRepository _orderRepository;

		public OrdersController(IMediator mediator, IOrdersRepository orderRepository)
		{
			_mediator = mediator;
			_orderRepository = orderRepository;
		}

		[HttpPost]
		public async Task<IActionResult> CreateOrders(CreateOrdersCommand command)
		{
			await _mediator.Send(command);
			return Ok("Sipariş Başarılı Bir Şekilde Oluşturuldu");
		}
		[HttpGet]
		public async Task<IActionResult> OrderList()
		{
			var values = await _mediator.Send(new GetOrdersQuery());
			return Ok(values);
		}
		[HttpGet("restaurant/{restaurantId}")]
		public async Task<IActionResult> GetOrdersByRestaurantId([BindRequired] Guid restaurantId)
		{
			var values = await _mediator.Send(new GetOrdersListByRestaurantIdQuery(restaurantId));
			return Ok(values);
		}
		[HttpGet("{orderId}")]
		public async Task<IActionResult> GetOrdersById([BindRequired] Guid orderId)
		{
			var values = await _mediator.Send(new GetOrdersByIdQuery(orderId));
			if(values.Id != Guid.Empty)
			{
				return Ok(values);
			}
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveOrders([BindRequired] Guid id)
		{
			await _mediator.Send(new RemoveOrdersCommand(id));
			return Ok("Sipariş Başarıyla silindi");
		}
				
	}
}
