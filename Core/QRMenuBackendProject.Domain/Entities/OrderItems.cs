using QRMenuBackendProject.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Domain.Entities
{
	public class OrderItems : AuditableEntity
	{
		[ForeignKey("MenuItemId")]
		public Guid MenuItemId { get; set; }
		public MenuItem MenuItems { get; set; }
        public int Quantity { get; set; } // Sipariş edilen ürün miktarı							  	
		public int Price { get; set; }

		[ForeignKey("OrdersId")]
		public Guid OrdersId { get; set; }
		public Orders Orders { get; set; }
	}
}
