using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerManagement.Application.DTOs;
using CustomerManagement.Application.Services;
using CustomerManagement.Domain.Entities;

namespace CustomerManagement.Application.Interface
{
    public interface IProductService
    {
        Task<ApiResponse<ProductResponseDto>> SaveAsync(ProductSaveDto dto);// common for Add/Update
        Task<ApiResponse<ProductResponseDto?>> GetByIdAsync(int id);
        Task<ApiResponse<IEnumerable<ProductResponseDto>>> GetAllAsync();
       
        Task<ApiResponse<bool>> DeleteAsync(int id);
        
    }
}
