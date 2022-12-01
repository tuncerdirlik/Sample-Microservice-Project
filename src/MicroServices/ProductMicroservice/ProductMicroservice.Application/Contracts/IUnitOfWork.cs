namespace ProductMicroservice.Application.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }

        Task SaveAsync();
    }
}
