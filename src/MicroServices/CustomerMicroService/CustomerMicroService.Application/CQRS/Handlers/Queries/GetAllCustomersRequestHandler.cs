using AutoMapper;
using CustomerMicroService.Application.Contracts;
using CustomerMicroService.Application.CQRS.Requests.Queries;
using CustomerMicroService.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMicroService.Application.CQRS.Handlers.Queries
{
    public class GetAllCustomersRequestHandler : IRequestHandler<GetAllCustomersRequest, BaseResponse<List<CustomerDto>>>
    {
        private ICustomerRepository _customerRepository;
        private IMapper _mapper;

        public GetAllCustomersRequestHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<CustomerDto>>> Handle(GetAllCustomersRequest request, CancellationToken cancellationToken)
        {
            var respone = new BaseResponse<List<CustomerDto>>();
            var items = await _customerRepository.GetAllAsync();

            respone.Success = true;
            respone.Data = _mapper.Map<List<CustomerDto>>(items);

            return respone;
        }
    }
}
