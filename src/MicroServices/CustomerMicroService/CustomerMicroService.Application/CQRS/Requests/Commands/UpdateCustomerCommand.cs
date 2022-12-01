using CustomerMicroService.Application.DTOs;
using MediatR;

namespace CustomerMicroService.Application.CQRS.Requests.Commands
{
    public class UpdateCustomerCommand : IRequest<BaseResponse<CustomerDto>>
    {
        public CustomerDto CustomerDto { get; set; }
    }
}
