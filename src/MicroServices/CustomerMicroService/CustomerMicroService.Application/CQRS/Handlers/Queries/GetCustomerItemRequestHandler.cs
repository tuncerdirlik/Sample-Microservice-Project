using AutoMapper;
using CustomerMicroService.Application.Contracts;
using CustomerMicroService.Application.CQRS.Requests.Queries;
using CustomerMicroService.Application.DTOs;
using MediatR;

namespace CustomerMicroService.Application.CQRS.Handlers.Queries
{
    public class GetCustomerItemRequestHandler : IRequestHandler<GetCustomerItemRequest, BaseResponse<CustomerDto>>
    {
        private ICustomerRepository _customerRepository;
        private IMapper _mapper;

        public GetCustomerItemRequestHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<CustomerDto>> Handle(GetCustomerItemRequest request, CancellationToken cancellationToken)
        {
            var respone = new BaseResponse<CustomerDto>();

            var item = await _customerRepository.GetAsync(request.Id);
            if (item == null)
            {
                respone.Success = false;
                respone.Errors = new List<string>() { "item not found" };
            }
            else
            {
                respone.Success = true;
                respone.Data = _mapper.Map<CustomerDto>(item);
            }

            return respone;
        }
    }
}
