using QRMenuBackendProject.Application.Features.Mediator.Results.MenuResults.MenuItemResults;
using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Results.MenuResults
{
	public class GetMenuQueryResult
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Guid RestaurantId { get; set; }
		public string RestaurantName { get; set; }
		public List<GetMenuItemQueryResult>? MenuItems { get; set; }
	}
}
