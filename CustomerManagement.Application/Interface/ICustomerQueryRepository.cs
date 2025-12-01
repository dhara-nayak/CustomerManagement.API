using CustomerManagement.Application.DTOs;
using CustomerManagement.Domain.Entities;

namespace CustomerManagement.Application.Interface
{
    public interface ICustomerQueryRepository
    {
        Task<CustomerPurchaseSummaryDto> GetCustomerDetailsByEmailAsync(string email);
    }
}
