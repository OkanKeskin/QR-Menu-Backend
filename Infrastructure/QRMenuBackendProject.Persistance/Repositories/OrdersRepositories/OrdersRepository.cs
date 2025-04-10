using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QRMenuBackendProject.Application.Features.Mediator.Commands.OrdersCommands;
using QRMenuBackendProject.Application.Features.Mediator.Results.OrdersResults;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Application.Interfaces.OrdersInterface;
using QRMenuBackendProject.Domain.Entities;
using QRMenuBackendProject.Persistance.Context;

namespace QRMenuBackendProject.Persistance.Repositories.OrdersRepositories
{
	public class OrdersRepository : Repository<Orders>, IOrdersRepository
	{
		public OrdersRepository(QRMenuBackendProjectContext context) : base(context)
		{ }

		public async Task CreateOrder(CreateOrdersCommand dto)
		{
			Orders orders = new Orders();
			orders.PaymentType = dto.PaymentType;
			orders.RestaurantTableId = dto.RestaurantTableId;
			orders.CreatedAt = DateTime.UtcNow;
			orders.OrderItems = new List<OrderItems>();
			if(dto.OrderItems != null)
			{
				foreach(var item in dto.OrderItems)
				{
					OrderItems orderItems = new OrderItems();
					orderItems.OrdersId = orders.Id;
					orderItems.MenuItemId = item.MenuItemId;
					orderItems.Price= item.Price;
					orderItems.Quantity= item.Quantity;
					orderItems.CreatedAt = DateTime.UtcNow;
					orders.OrderItems.Add(orderItems);
				}
			}
			if(dto.PaymentType.ToString() == "2")
			{
				orders.Paid = true;
				Invoice invoice = new Invoice();
				invoice.OrdersId=orders.Id;
				invoice.Total=orders.OrderItems.Sum(x=> x.Price*x.Quantity);
				invoice.ProccesDate= DateTime.UtcNow;
				invoice.CreatedAt= DateTime.UtcNow;
				_context.Set<Invoice>().Add(invoice);
			}
			
			_context.Set<Orders>().Add(orders);
			await _context.SaveChangesAsync();
		}
		public async Task<List<Orders>> GetListByRestaurantId(Guid restaurantId)
		{
			var result= await _context.Set<Orders>()
				.Include(x => x.OrderItems).ThenInclude(x => x.MenuItems)
								 .Include(x => x.RestaurantTable)
									.ThenInclude(x => x.Restaurant)
								 .ToListAsync();
			if(result.Count > 0)
			{
				result = result.Where(x => x.RestaurantTable.RestaurantId == restaurantId).ToList();
			}
			return result;
		}

		public async Task<List<Orders>> ListAllOrders()
		{
			return await _context.Set<Orders>().Include(x=> x.OrderItems).ThenInclude(x=> x.MenuItems).ToListAsync();
		}

		public async Task<Orders> FindOrder(Guid id)
		{
			return await _context.Set<Orders>().Include(x => x.OrderItems).ThenInclude(x => x.MenuItems).FirstOrDefaultAsync(x=> x.Id==id);
		}
		
	}
}
