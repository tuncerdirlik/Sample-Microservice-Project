using CustomerMicroService.Application.DTOs;
using MediatR;

namespace CustomerMicroService.Application.CQRS.Requests.Commands
{
    public class CreateCustomerCommand : IRequest<BaseResponse<CustomerDto>>
    {
        public CreateCustomerDto CreateCustomerDto { get; set; }
    }
}
