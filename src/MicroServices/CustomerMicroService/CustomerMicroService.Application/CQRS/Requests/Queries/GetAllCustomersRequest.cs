using CustomerMicroService.Application.DTOs;
using MediatR;

namespace CustomerMicroService.Application.CQRS.Requests.Queries
{
    public class GetAllCustomersRequest : IRequest<BaseResponse<List<CustomerDto>>>
    {
    }
}
