using Azure;
using CustomerManagement.Application.DTOs;
using CustomerManagement.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.API.Controllers
{
    //  Every API requires JWT Token
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;


        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save(ProductSaveDto dto)
        {
            var response = await _service.SaveAsync(dto);
           if (!response.Success)
                return BadRequest(new { response.Message });
           return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _service.GetByIdAsync(id);
            if (!response.Success || response.Data == null)
                return NotFound(new { response.Message });
            return Ok(response.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()  
        {
            var response = await _service.GetAllAsync();
            if (!response.Success || response.Data == null)
                return NotFound(new { response.Message });
            return Ok(response.Data);
        }

      
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response  = await _service.DeleteAsync(id);

            if (!response.Success || response.Data == false)
                return NotFound(new { response.Message });

            return Ok(new { response.Message });
        }
    }
}

 