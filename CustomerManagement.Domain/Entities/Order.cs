using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
