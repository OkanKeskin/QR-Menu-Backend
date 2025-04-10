using QRMenuBackendProject.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Domain.Entities
{
    public class Categories : AuditableEntity
    {
        public string CategoryName { get; set; }

		[ForeignKey("MenuId")]
		public Guid MenuId { get; set; }
		public Menu Menu { get; set; }
		public ICollection<MenuItem> MenuItems { get; set; }
	}
}
