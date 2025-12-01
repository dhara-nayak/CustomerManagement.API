using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerManagement.Application.DTOs;

namespace CustomerManagement.Application.Interface
{
    public interface ICustomerQueryService
    {
        Task<CustomerPurchaseSummaryDto?> GetMyPurchaseAsync(string email);
    }
}
