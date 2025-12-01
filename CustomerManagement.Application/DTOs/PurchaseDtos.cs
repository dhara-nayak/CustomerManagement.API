using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.DTOs
{
    public class ProductBasicDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class CustomerPurchaseSummaryDto
    {
        public String CustomerName { get; set; } = " ";
        public String Email { get; set; } = " ";
        public List<ProductBasicDto> PurchasedProducts { get; set; } = new();
    }
}
