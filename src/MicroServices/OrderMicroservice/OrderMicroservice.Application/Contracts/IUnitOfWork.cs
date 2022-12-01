namespace OrderMicroservice.Application.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository OrderRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }

        Task SaveAsync();
    }
}
