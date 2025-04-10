using QRMenuBackendProject.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Domain.Entities
{
    public class MenuItem : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
		[ForeignKey("MenuId")]
		public Guid MenuId { get; set; }
        public Menu Menu { get; set; }       
        public Guid CategoriesId { get; set; }
		public Categories Categories { get; set; }
		public string ContentType { get; set; } //fotoğrafın eklendiği klasör
	}
}
