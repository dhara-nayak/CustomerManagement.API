using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerManagement.Domain.Entities;

namespace CustomerManagement.Application.Interface
{
    public interface IProductRepository
    {
        Task<Product> AddAsync(Product product);
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> UpdateAsync(Product product);
        
        Task<bool> DeleteAsync(int id); // delete by id
    }
}
