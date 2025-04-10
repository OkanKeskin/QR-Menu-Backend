using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Commands.FavoriteRestaurantCommands
{
	public class RemoveFavoriteRestaurantCommand : IRequest
	{
		public Guid Id { get; set; }

		public RemoveFavoriteRestaurantCommand(Guid id)
		{
			Id = id;
		}
	}
}
