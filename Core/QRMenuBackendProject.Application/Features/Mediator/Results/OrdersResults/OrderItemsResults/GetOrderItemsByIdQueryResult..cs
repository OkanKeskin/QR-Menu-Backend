using QRMenuBackendProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuBackendProject.Application.Features.Mediator.Results.OrdersResults.OrderItemsResults
{
	public class GetOrderItemsByIdQueryResult
	{
        public Guid Id { get; set; }
        public Guid MenuItemId { get; set; }
		public string MenuItemName { get; set; }
		public int Quantity { get; set; } // Sipariş edilen ürün miktarı							  	
		public int Price { get; set; }
		public Guid OrdersId { get; set; }
	}
}
