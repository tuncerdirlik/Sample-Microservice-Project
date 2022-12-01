using CustomerMicroService.Application.Contracts;
using CustomerMicroService.Domain;

namespace CustomerMicroService.Persistance.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly AppDbContext _dbContext;

        public CustomerRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
