using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerManagement.Application.DTOs;
using CustomerManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace CustomerManagement.Application.Interface
{
    public interface ICustomerService
    {
        Task<Customer> AddAsync(AddCustomerDto dto);
        Task<Customer?> UpdateAsync(int id, EditCustomerDto dto);
        Task<bool> DeleteAsync(int id);
        Task<Customer?> GetByIdAsync(int id);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer?> LoginAsync(LoginDto dto);

    }
}


// ApplicationException layer defines service contracts(use cases). Implementation will be in infrastructure.

//Declare methods for use-cases: GetAllAsync, GetByIdAsync, CreateAsync, UpdateAsync, DeleteAsync.

//Purpose: controllers depend on this contract.Implementations (Infrastructure) can change without affecting API.

