using Jimmys20.BlazorComponents.Demo.Models;

namespace Jimmys20.BlazorComponents.Demo.Services
{
    public class CustomerService
    {
        public static IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
                new Customer { Id = 1, Name = "Jim", Index = 0 },
                new Customer { Id = 2, Name = "George", Index = 2 },
                new Customer { Id = 3, Name = "John", Index = 5 },
                new Customer { Id = 4, Name = "Lisa", Index = 9 },
            };
        }
    }
}
