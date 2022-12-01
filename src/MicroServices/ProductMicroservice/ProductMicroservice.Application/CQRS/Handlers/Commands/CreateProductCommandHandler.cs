using AutoMapper;
using MediatR;
using ProductMicroservice.Application.Contracts;
using ProductMicroservice.Application.CQRS.Requests.Commands;
using ProductMicroservice.Application.DTOs;
using ProductMicroservice.Application.DTOs.Validators;
using ProductMicroservice.Domain;

namespace ProductMicroservice.Application.CQRS.Handlers.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseResponse<ProductDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<ProductDto>();
            var validator = new CreateProductDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateProductDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                var product = _mapper.Map<Product>(request.CreateProductDto);

                var dbItem = await _unitOfWork.ProductRepository.AddAsync(product);
                await _unitOfWork.SaveAsync();

                response.Success = true;
                response.Data = _mapper.Map<ProductDto>(dbItem);
            }

            return response;
        }
    }
}
