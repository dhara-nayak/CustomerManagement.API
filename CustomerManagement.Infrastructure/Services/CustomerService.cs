using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CustomerManagement.Application.DTOs;
using CustomerManagement.Application.Interface;
using CustomerManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _db;
        public CustomerService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Customer> AddAsync(AddCustomerDto dto)
        {
            var hashPassword = HashPassword(dto.Password);

            var customer = new Customer
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                Address = dto.Address,
                DateOfBirth = dto.DateOfBirth,
                PasswordHash = hashPassword,
            };

            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();
            return customer;
        }


        //Update
        public async Task<Customer?> UpdateAsync(int id, EditCustomerDto dto)
        {
            var customer = await _db.Customers.FindAsync(id);
            if (customer == null) return null;

            //only update allow fields
            customer.FirstName = dto.FirstName;
            customer.LastName = dto.LastName;
            customer.Phone = dto.Phone;
            customer.Address = dto.Address;
            customer.DateOfBirth = dto.DateOfBirth;

            await _db.SaveChangesAsync();
            return customer;
        }

        //Delete
        public async Task<bool> DeleteAsync(int id)
        {
            var customer = await _db.Customers.FindAsync(id);
            if (customer == null) return false;
            _db.Customers.Remove(customer);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Customer?> GetByIdAsync(int id) =>
            await _db.Customers.FindAsync(id);

        public async Task<IEnumerable<Customer>> GetAllAsync() =>
            await _db.Customers.ToListAsync();

        public async Task<Customer?> LoginAsync(LoginDto dto)
        {
            var hashedPassword = HashPassword(dto.Password);
            return await _db.Customers
                .FirstOrDefaultAsync(c => c.Email == dto.Email && c.PasswordHash == hashedPassword);
        }

        private string HashPassword(string password)
        {
            // Simple example — use proper hashing in production (e.g., BCrypt)
            using var sha256 = SHA256.Create();
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }




    }
}








