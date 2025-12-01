using CustomerManagement.Application.DTOs;

namespace CustomerManagement.Application.Services
{
    public class ApiResponse<T> : ProductResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
    }
}