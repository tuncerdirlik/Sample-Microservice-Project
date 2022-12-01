using CommonObjects.MessageCommands;
using MassTransit;
using ProductMicroservice.Application.Contracts;

namespace ProductMicroservice.Application.Consumers
{
    public class ChangeProductStockCommandConsumer : IConsumer<ChangeProductStockCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChangeProductStockCommandConsumer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<ChangeProductStockCommand> context)
        {
            await _unitOfWork.ProductRepository.UpdateProductStock(context.Message.ProductId, context.Message.UsedStockCount);
            await _unitOfWork.SaveAsync();
        }
    }
}
