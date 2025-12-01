using AutoMapper;
using CustomerManagement.Application.DTOs;
using CustomerManagement.Application.Interface;
using CustomerManagement.Domain.Entities;

namespace CustomerManagement.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ApiResponse<ProductResponseDto>> SaveAsync(ProductSaveDto dto)
        {
            try
            {
                Product product;

                if (dto.Id == null || dto.Id == 0) //ADD
                {
                    product = _mapper.Map<Product>(dto);
                    product = await _repository.AddAsync(product);

                    return new ApiResponse<ProductResponseDto>
                    {
                        Success = true,
                        Message = "Product added Successfully",
                        Data = _mapper.Map<ProductResponseDto>(product)
                    };
                }

                else //UPDATE
                {
                    product = await _repository.GetByIdAsync(dto.Id.Value)
                       ?? throw new Exception("Product not found");

                    //Map Update values from DTO -> Entity
                    _mapper.Map(dto, product);
                    product = await _repository.UpdateAsync(product);

                    return new ApiResponse<ProductResponseDto>
                    {
                        Success = true,
                        Message = "Product updated Successfully",
                        Data = _mapper.Map<ProductResponseDto>(product)
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<ProductResponseDto>
                {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }

        public async Task<ApiResponse<IEnumerable<ProductResponseDto>>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();


            return new ApiResponse<IEnumerable<ProductResponseDto>>
            {
                Success = true,
                Message = "Products retrieved successfully",
                Data = _mapper.Map<IEnumerable<ProductResponseDto>>(products)
            }; 

        }

        public async Task<ApiResponse<ProductResponseDto?>> GetByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
            {
                return new ApiResponse<ProductResponseDto?>
                {
                    Success = false,
                    Message = "Product not found"
                };
            }
            return new ApiResponse<ProductResponseDto?>
            {
                Success = true,
                Message = "Product retrieved successfully",
                Data = _mapper.Map<ProductResponseDto>(product)
            };

        }


        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if(!deleted)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = "Product not found",
                    Data = false

                };
            }
            return new ApiResponse<bool>
            {
                Success = true,
                Message = "Product deleted successfully",
                Data = true
            };

        }
    }
}