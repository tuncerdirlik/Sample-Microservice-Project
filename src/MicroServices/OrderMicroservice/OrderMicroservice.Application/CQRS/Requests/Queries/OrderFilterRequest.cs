using MediatR;
using OrderMicroservice.Application.DTOs;

namespace OrderMicroservice.Application.CQRS.Requests.Queries
{
    public class OrderFilterRequest : IRequest<BaseResponse<List<OrderDto>>>
    {
        public OrderFilterDto OrderFilter { get; set; }
    }
}
