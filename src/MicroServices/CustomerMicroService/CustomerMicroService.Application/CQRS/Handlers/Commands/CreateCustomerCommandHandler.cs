using AutoMapper;
using CustomerMicroService.Application.Contracts;
using CustomerMicroService.Application.CQRS.Requests.Commands;
using CustomerMicroService.Application.DTOs;
using CustomerMicroService.Domain;
using MediatR;

namespace CustomerMicroService.Application.CQRS.Handlers.Commands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, BaseResponse<CustomerDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<CustomerDto>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<CustomerDto>();

            var customer = _mapper.Map<Customer>(request.CreateCustomerDto);

            var dbItem = await _unitOfWork.CustomerRepository.AddAsync(customer);
            await _unitOfWork.SaveAsync();

            response.Success = true;
            response.Data = _mapper.Map<CustomerDto>(dbItem);

            return response;
        }
    }
}
