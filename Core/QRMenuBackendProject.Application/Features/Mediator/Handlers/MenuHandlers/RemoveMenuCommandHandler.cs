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
	public class RemoveMenuCommandHandler : IRequestHandler<RemoveMenuCommand>
	{
		private readonly IRepository<Menu> _repository;

		public RemoveMenuCommandHandler(IRepository<Menu> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveMenuCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}
