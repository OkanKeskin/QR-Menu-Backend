using QRMenuBackendProject.Application.Features.Mediator.Commands.OrdersCommands.OrderItemsCommands;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Interfaces.OrderItemsInterface
{
	public interface IOrderItemsRepository : IRepository<OrderItems>
	{
		Task CreateOrderItems(CreateOrderItemsCommand dto);
		Task UpdateOrderItems(UpdateOrderItemsCommand dto);
		Task<List<OrderItems>> ListAllOrderItems();
		Task<OrderItems> FindOrderItem(Guid id);
		Task RemoveOrderItem(Guid id);
	}
}
