using AutoMapper;
using MediatR;
using OrderMicroservice.Application.Contracts;
using OrderMicroservice.Application.CQRS.Requests.Commands;
using OrderMicroservice.Application.DTOs;
using OrderMicroservice.Domain;

namespace OrderMicroservice.Application.CQRS.Handlers.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, BaseResponse<CreateOrderDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<CreateOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<CreateOrderDto>();

            var order = _mapper.Map<Order>(request.CreateOrderDto);
            order.IsSuccess = true;
            order.TotalPrice = request.CreateOrderDto.OrderItems.Sum(k => k.Count * k.Price);

            await _unitOfWork.OrderRepository.AddAsync(order);
            await _unitOfWork.SaveAsync();

            response.Success = true;

            return response;
        }
    }
}
