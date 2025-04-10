using Microsoft.EntityFrameworkCore;
using QRMenuBackendProject.Application.Interfaces.OrdersInterface;
using QRMenuBackendProject.Application.Interfaces.RestaurantInterface;
using QRMenuBackendProject.Domain.Entities;
using QRMenuBackendProject.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Persistance.Repositories.RestaurantRepositories
{
	public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
	{
		public RestaurantRepository(QRMenuBackendProjectContext context) : base(context)
		{ }

		public async Task<List<Restaurant>> ListAllRestaurantByUserId(Guid userId)
		{
			//return await _context.Set<Restaurant>().Include(x => x.Accounts.Id==userId).ToListAsync();
			return await _context.Set<Restaurant>()
				.Include(x => x.Accounts)
				.Where(r => r.Accounts.Id == userId)
				.ToListAsync();
		}
	}
}
