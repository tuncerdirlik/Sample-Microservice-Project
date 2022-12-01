namespace CustomerMicroService.Application.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }

        Task SaveAsync();
    }
}
