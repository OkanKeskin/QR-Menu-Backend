using QRMenuBackendProject.Application.Features.Mediator.Commands.OrdersCommands;
using QRMenuBackendProject.Application.Features.Mediator.Results.OrdersResults;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Interfaces.OrdersInterface
{
	public interface IOrdersRepository : IRepository<Orders>
	{
		Task CreateOrder(CreateOrdersCommand dto);
		Task<List<Orders>> ListAllOrders();
		Task<List<Orders>> GetListByRestaurantId(Guid restaurantId);
		Task<Orders> FindOrder(Guid id);
	}
}
