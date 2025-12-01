using CustomerManagement.Application.DTOs;
using CustomerManagement.Application.Interface;
using CustomerManagement.Domain.Entities;

namespace CustomerManagement.Infrastructure.Services
{
    public class CustomerQueryService(ICustomerQueryRepository customerQueryRepository) : ICustomerQueryService
    {
        public Task<CustomerPurchaseSummaryDto?> GetMyPurchaseAsync(string email)
        {
            return GetMyPurchasesAsync(email); // reuse existing method
        }


        public async Task<CustomerPurchaseSummaryDto?> GetMyPurchasesAsync(string email)
        {
            // Get customer entity from repository
            CustomerPurchaseSummaryDto customerDetails = await customerQueryRepository.GetCustomerDetailsByEmailAsync(email);

            if (customerDetails == null)
                return null;

            //// Manually map Customer -> CustomerPurchaseSummaryDto
            //var result = new CustomerPurchaseSummaryDto
            //{
            //    CustomerName = customerDetails.FirstName + " " + customerDetails.LastName,
            //    Email = customerDetails.Email,
            //    PurchasedProducts = customerDetails.Orders
            //        .SelectMany(o => o.Items)
            //        .Select(oi => new ProductBasicDto
            //        {
            //            Id = oi.Product.Id,
            //            Name = oi.Product.Name,
            //            Price = oi.Product.Price
            //        })
            //        .Distinct()
            //        .ToList()
            //};

            return customerDetails;
        }

    }
}