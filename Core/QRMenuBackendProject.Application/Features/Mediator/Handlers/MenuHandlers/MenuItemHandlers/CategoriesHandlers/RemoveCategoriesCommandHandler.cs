using MediatR;
using QRMenuBackendProject.Application.Features.Mediator.Commands.MenuCommands.MenuItemCommands.CategoriesCommands;
using QRMenuBackendProject.Application.Interfaces;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Handlers.MenuHandlers.MenuItemHandlers.CategoriesHandlers
{
	public class RemoveCategoriesCommandHandler : IRequestHandler<RemoveCategoriesCommand>
	{
		private readonly IRepository<Categories> _repository;

		public RemoveCategoriesCommandHandler(IRepository<Categories> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveCategoriesCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}
