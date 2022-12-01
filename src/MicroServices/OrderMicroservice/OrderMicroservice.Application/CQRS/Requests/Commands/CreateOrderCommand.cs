using MediatR;
using OrderMicroservice.Application.DTOs;

namespace OrderMicroservice.Application.CQRS.Requests.Commands
{
    public class CreateOrderCommand : IRequest<BaseResponse<CreateOrderDto>>
    {
        public CreateOrderDto CreateOrderDto { get; set; }
    }
}
