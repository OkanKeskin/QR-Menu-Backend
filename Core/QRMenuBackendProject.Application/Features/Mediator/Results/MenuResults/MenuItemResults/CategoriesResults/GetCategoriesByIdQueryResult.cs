using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Results.MenuResults.MenuItemResults.CategoriesResults
{
	public class GetCategoriesByIdQueryResult
	{
		public Guid Id { get; set; }
		public string CategoryName { get; set; }
        public string MenuName { get; set; }
		public Guid MenuId { get; set; }
		public List<GetMenuItemQueryResult> Items { get; set; }
	}
}
