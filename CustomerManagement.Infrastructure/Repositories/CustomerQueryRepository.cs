using CustomerManagement.Application.DTOs;
using CustomerManagement.Application.Interface;
using CustomerManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Infrastructure.Repositories
{
    public class CustomerQueryRepository(AppDbContext context) : ICustomerQueryRepository
    {
        public async Task<CustomerPurchaseSummaryDto?> GetCustomerDetailsByEmailAsync(string email)
        {
            // Method syntax (EF friendly), projecting only needed fields
            return await context.Customers
            .Where(c => c.Email == email)
            .Select(c => new CustomerPurchaseSummaryDto//Projects into DTO
            {
                CustomerName = c.FirstName + " " + c.LastName,
                Email = c.Email,


                PurchasedProducts = c.Orders//Purchased Products
                    .SelectMany(o => o.Items)
 

                    .Select(oi => new ProductBasicDto
                    {
                        Id = oi.Product.Id,
                        Name = oi.Product.Name,
                        Price = oi.Product.Price
                    })
                    .Distinct()//Remoove Duplicates(if customer purchased same product multiple times
                    .ToList()//convert to list
            }).FirstOrDefaultAsync();//return the first customer found with that email pr null if not exist
        }
    }
}
