using Microsoft.EntityFrameworkCore;
using QRMenuBackendProject.Application.Interfaces.FavoriteRestaurantInterface;
using QRMenuBackendProject.Domain.Entities;
using QRMenuBackendProject.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Persistance.Repositories.FavoriteRestaurantRepositories
{
	public class FavoriteRestaurantRepository:Repository<FavoriteRestaurant>, IFavoriteRestaurantRepository
	{
		public FavoriteRestaurantRepository(QRMenuBackendProjectContext context) : base(context)
		{ }

		public async Task<List<FavoriteRestaurant>> ListFavoriteRestaurant(Guid customerId)
		{
			var result = await _context.Set<FavoriteRestaurant>().Include(x => x.Customer).Include(x => x.Restaurant).Where(x=> x.CustomerId==customerId).ToListAsync();

			if(result.Count() > 0)
			{
				foreach(var item in result)
				{
					if(item.CustomerId != Guid.Empty)
					{
						var cstmr=await _context.Set<Customer>().Where(x=> x.Id==item.CustomerId).FirstOrDefaultAsync();
						if(cstmr != null)
						{
							item.Customer=cstmr;
						}
					}
				}
			}

			return result;
		}
	}
}
