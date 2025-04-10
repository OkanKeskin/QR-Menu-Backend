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
	public class UpdateCategoriesCommandHandler : IRequestHandler<UpdateCategoriesCommand>
	{
		private readonly IRepository<Categories> _repository;

		public UpdateCategoriesCommandHandler(IRepository<Categories> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateCategoriesCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			values.CategoryName = request.CategoryName;
			values.MenuId = request.MenuId;

			await _repository.UpdateAsync(values);
		}
	}
}
