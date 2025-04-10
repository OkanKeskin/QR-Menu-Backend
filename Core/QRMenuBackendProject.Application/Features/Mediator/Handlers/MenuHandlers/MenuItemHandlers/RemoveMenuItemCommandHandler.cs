using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Commands.MenuCommands.MenuItemCommands;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.MenuHandlers.MenuItemHandlers
{
	public class RemoveMenuItemCommandHandler : IRequestHandler<RemoveMenuItemCommand>
	{
		private readonly IRepository<MenuItem> _repository;

		public RemoveMenuItemCommandHandler(IRepository<MenuItem> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveMenuItemCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}
