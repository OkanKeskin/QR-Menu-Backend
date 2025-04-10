using QRMenuBackendProject.Application.Features.Mediator.Commands.OrdersCommands;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Interfaces.RestaurantInterface
{
	public interface IRestaurantRepository : IRepository<Restaurant>
	{
		Task<List<Restaurant>> ListAllRestaurantByUserId(Guid userId);
	}
}
