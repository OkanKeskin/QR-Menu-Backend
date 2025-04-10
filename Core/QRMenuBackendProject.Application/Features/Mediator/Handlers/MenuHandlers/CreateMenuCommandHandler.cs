using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Commands.MenuCommands;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.MenuHandlers
{
	public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand>
	{
		private readonly IRepository<Menu> _repository;

		public CreateMenuCommandHandler(IRepository<Menu> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateMenuCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Menu
			{
				Name = request.Name,
				RestaurantId = request.RestaurantId,
			});
		}
	}
}
