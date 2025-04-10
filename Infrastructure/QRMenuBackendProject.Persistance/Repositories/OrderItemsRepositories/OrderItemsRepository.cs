using Microsoft.EntityFrameworkCore;
using QRMenuBackendProject.Application.Features.Mediator.Commands.OrdersCommands.OrderItemsCommands;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Application.Interfaces.OrderItemsInterface;
using QRMenuBackendProject.Domain.Entities;
using QRMenuBackendProject.Persistance.Context;

namespace QRMenuBackendProject.Persistance.Repositories.OrderItemsRepositories
{
	public class OrderItemsRepository : Repository<OrderItems>, IOrderItemsRepository
	{
		private readonly IRepository<OrderItems> _repository;
		public OrderItemsRepository(QRMenuBackendProjectContext context) : base(context)
		{ }

		public async Task CreateOrderItems(CreateOrderItemsCommand dto)
		{
			OrderItems orderItems = new OrderItems();
			orderItems.OrdersId = dto.OrdersId;
			orderItems.MenuItemId = dto.MenuItemId;
			orderItems.Price = dto.Price;
			orderItems.Quantity = dto.Quantity;
			orderItems.CreatedAt = DateTime.UtcNow;
			var orderEntity = await _context.Set<Orders>().Include(x => x.OrderItems).FirstOrDefaultAsync(x => x.Id == dto.OrdersId);
			if (orderEntity != null)
			{
				if (orderEntity.Paid == true)
				{
					var invoiceEntity = await _context.Set<Invoice>().Include(x => x.Orders).FirstOrDefaultAsync(x => x.OrdersId == dto.OrdersId);
					if (invoiceEntity != null)
					{
						invoiceEntity.Total = invoiceEntity.Total + (dto.Quantity * dto.Price);
						invoiceEntity.UpdatedAt = DateTime.UtcNow;
						_context.Set<Invoice>().Update(invoiceEntity);
					}
				}
			}
			_context.Set<OrderItems>().Add(orderItems);
			await _context.SaveChangesAsync();
		}
		public async Task UpdateOrderItems(UpdateOrderItemsCommand dto)
		{
			var entity = await _context.Set<OrderItems>().Include(x => x.Orders).FirstOrDefaultAsync(x => x.Id == dto.Id);
			if (entity != null)
			{
				entity.UpdatedAt = DateTime.UtcNow;
				entity.Quantity = dto.Quantity;
				if (entity.Orders.Paid == true)
				{
					var invoiceEntity = await _context.Set<Invoice>().Include(x => x.Orders).FirstOrDefaultAsync(x => x.OrdersId == entity.OrdersId);
					if (invoiceEntity != null)
					{

						invoiceEntity.Total = invoiceEntity.Total - (entity.Quantity * entity.Price);
						invoiceEntity.Total = invoiceEntity.Total + (dto.Quantity * entity.Price);
						invoiceEntity.UpdatedAt = DateTime.UtcNow;
						_context.Set<Invoice>().Update(invoiceEntity);
					}
				}

				_context.Set<OrderItems>().Update(entity);
				await _context.SaveChangesAsync();
			}
		}
		public async Task<OrderItems> FindOrderItem(Guid id)
		{
			return await _context.Set<OrderItems>().Include(x => x.Orders).Include(x => x.MenuItems).FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<List<OrderItems>> ListAllOrderItems()
		{
			return await _context.Set<OrderItems>().Include(x => x.Orders).Include(x => x.MenuItems).ToListAsync();
		}

		public async Task RemoveOrderItem(Guid id)
		{
			var orderItem = _context.Set<OrderItems>().Include(x => x.Orders).FirstOrDefault(x => x.Id == id);
			if (orderItem != null)
			{
				if (orderItem.Orders.Paid == true)
				{
					var invoiceEntity = await _context.Set<Invoice>().Include(x => x.Orders).FirstOrDefaultAsync(x => x.OrdersId == orderItem.OrdersId);
					if (invoiceEntity != null)
					{
						invoiceEntity.Total = invoiceEntity.Total - (orderItem.Quantity * orderItem.Price);
						invoiceEntity.UpdatedAt = DateTime.UtcNow;
						_context.Set<Invoice>().Update(invoiceEntity);
					}
				}
				_context.Remove(orderItem);
				_context.SaveChanges();
			}
		}
	}



}
