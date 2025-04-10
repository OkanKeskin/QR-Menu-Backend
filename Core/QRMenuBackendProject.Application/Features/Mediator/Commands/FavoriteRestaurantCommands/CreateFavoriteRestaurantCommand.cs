using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Commands.FavoriteRestaurantCommands
{
	public class CreateFavoriteRestaurantCommand :  IRequest
	{
		public Guid CustomerId { get; set; }
		public Guid RestaurantId { get; set; }
	}
}
