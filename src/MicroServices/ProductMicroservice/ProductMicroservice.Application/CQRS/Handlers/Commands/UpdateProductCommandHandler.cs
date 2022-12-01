using AutoMapper;
using MediatR;
using ProductMicroservice.Application.Contracts;
using ProductMicroservice.Application.CQRS.Requests.Commands;
using ProductMicroservice.Application.DTOs;

namespace ProductMicroservice.Application.CQRS.Handlers.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, BaseResponse<ProductDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<ProductDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<ProductDto>();  

            var dbItem = await _unitOfWork.ProductRepository.GetAsync(request.ProductDto.Id);
            if (dbItem == null)
            {
                response.Success= false;
                response.Errors = new List<string> { "Item not found" };
            }
            else
            {
                _mapper.Map(request.ProductDto, dbItem);
                await _unitOfWork.ProductRepository.UpdateAsync(dbItem);
                await _unitOfWork.SaveAsync();

                response.Success = true;
                response.Data = request.ProductDto;
            }

            return response;
        }
    }
}
