
namespace CustomerManagement.Application.Services
{
    internal class AppDbContext
    {
        public IEnumerable<object> Customers { get; internal set; }
        public IEnumerable<object> Orders { get; internal set; }
    }
}