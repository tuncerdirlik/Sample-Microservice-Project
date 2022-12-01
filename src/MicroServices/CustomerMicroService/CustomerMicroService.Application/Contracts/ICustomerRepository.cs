using CustomerMicroService.Domain;

namespace CustomerMicroService.Application.Contracts
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
    }
}
