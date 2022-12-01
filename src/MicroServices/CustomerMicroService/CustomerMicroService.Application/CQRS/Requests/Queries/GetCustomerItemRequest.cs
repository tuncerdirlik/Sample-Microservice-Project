using CustomerMicroService.Application.DTOs;
using MediatR;

namespace CustomerMicroService.Application.CQRS.Requests.Queries
{
    public class GetCustomerItemRequest : IRequest<BaseResponse<CustomerDto>>
    {
        public int Id { get; set; }
    }
}
