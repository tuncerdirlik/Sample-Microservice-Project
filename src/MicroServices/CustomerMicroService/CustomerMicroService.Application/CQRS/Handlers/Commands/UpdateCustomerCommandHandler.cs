using AutoMapper;
using CustomerMicroService.Application.Contracts;
using CustomerMicroService.Application.CQRS.Requests.Commands;
using CustomerMicroService.Application.DTOs;
using MediatR;

namespace CustomerMicroService.Application.CQRS.Handlers.Commands
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, BaseResponse<CustomerDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<CustomerDto>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<CustomerDto>();

            var dbItem = await _unitOfWork.CustomerRepository.GetAsync(request.CustomerDto.Id);
            if (dbItem == null)
            {
                response.Success = false;
                response.Errors = new List<string> { "Item not found" };
            }
            else
            {
                _mapper.Map(request.CustomerDto, dbItem);
                await _unitOfWork.CustomerRepository.UpdateAsync(dbItem);
                await _unitOfWork.SaveAsync();

                response.Success = true;
                response.Data = request.CustomerDto;
            }

            return response;
        }
    }
}
