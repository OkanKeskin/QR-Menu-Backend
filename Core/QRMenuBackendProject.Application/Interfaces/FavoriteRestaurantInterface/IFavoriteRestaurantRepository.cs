using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Interfaces.FavoriteRestaurantInterface
{
	public interface IFavoriteRestaurantRepository :IRepository<FavoriteRestaurant>
	{
		Task<List<FavoriteRestaurant>> ListFavoriteRestaurant(Guid customerId);
	}
}
