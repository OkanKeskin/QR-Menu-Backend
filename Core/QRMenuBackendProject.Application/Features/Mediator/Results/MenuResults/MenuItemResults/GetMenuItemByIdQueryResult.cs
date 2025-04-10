using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Results.MenuResults.MenuItemResults
{
	public class GetMenuItemByIdQueryResult
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string CatName { get; set; }
		public int Price { get; set; }
		public Guid MenuId { get; set; }
		public Guid CategoriesId { get; set; }
		public string ContentType { get; set; } //fotoğrafın eklendiği klasör
	}
}
