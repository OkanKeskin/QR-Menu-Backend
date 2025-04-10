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
	public class CreateCategoriesCommandHandler : IRequestHandler<CreateCategoriesCommand>
	{
		private readonly IRepository<Categories> _repository;

		public CreateCategoriesCommandHandler(IRepository<Categories> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateCategoriesCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Categories
			{
				CategoryName= request.CategoryName,
				MenuId= request.MenuId,
			});
		}
	}
}
