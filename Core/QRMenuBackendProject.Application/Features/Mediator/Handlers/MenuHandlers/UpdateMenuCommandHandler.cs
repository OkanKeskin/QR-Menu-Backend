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
	public class UpdateMenuCommandHandler : IRequestHandler<UpdateMenuCommand>
	{
		private readonly IRepository<Menu> _repository;

		public UpdateMenuCommandHandler(IRepository<Menu> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			values.Name = request.Name;
			values.RestaurantId = request.RestaurantId;
			await _repository.UpdateAsync(values);
		}
	}
}
