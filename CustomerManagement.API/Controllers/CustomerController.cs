using CustomerManagement.Application.DTOs;
using CustomerManagement.Application.Interface;
using CustomerManagement.Application.Services;
using CustomerManagement.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
     

        public CustomerController(ICustomerService service, ILogger<CustomerController> logger)
        {
            _service = service;
            
        }
        [HttpGet("Profile")]
        [Authorize]
        public IActionResult GetProfile()
        {
            var email = User.Identity?.Name ?? User.FindFirst("Sub")?.Value;
            var customerId = User.FindFirst("CustomerId")?.Value;

            return Ok(new
            {
                Message = "You are Authorized!",
                Email = email,
                CustomerId = customerId,
            });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Add(AddCustomerDto dto)
        {
            var customer = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        
        public async Task<IActionResult> Update(int id, EditCustomerDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _service.GetByIdAsync(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        [HttpPost("login")]
       
        public async Task<IActionResult> Login(LoginDto dto, [FromServices] JwtService jwtService)
        {
            var customer = await _service.LoginAsync(dto);
            if (customer == null) return Unauthorized("Invalid credencials");

            var token = jwtService.GenerateToken(customer.Email, customer.Id);
            return Ok(new
            {
                Token = token,
                Customer = new { customer.Id, customer.FirstName, customer.LastName, customer.Email }
            });
        }

    }

}
