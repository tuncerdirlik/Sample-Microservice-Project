using AutoMapper;
using MediatR;
using OrderMicroservice.Application.Contracts;
using OrderMicroservice.Application.CQRS.Requests.Queries;
using OrderMicroservice.Application.DTOs;

namespace OrderMicroservice.Application.CQRS.Handlers.Queries
{
    public class OrderFilterRequestHandler : IRequestHandler<OrderFilterRequest, BaseResponse<List<OrderDto>>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private IMapper _mapper;

        public OrderFilterRequestHandler(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<OrderDto>>> Handle(OrderFilterRequest request, CancellationToken cancellationToken)
        {
            var respone = new BaseResponse<List<OrderDto>>();
            var items = await _orderRepository.FilterOrdresAsync(request.OrderFilter);
            
            respone.Success = true;
            respone.Data = _mapper.Map<List<OrderDto>>(items);

            return respone;
        }
    }
}
