using AutoMapper;
using MediatR;
using ProductMicroservice.Application.Contracts;
using ProductMicroservice.Application.CQRS.Requests.Queries;
using ProductMicroservice.Application.DTOs;

namespace ProductMicroservice.Application.CQRS.Handlers.Queries
{
    public class GetProductItemRequestHandler : IRequestHandler<GetProductItemRequest, BaseResponse<ProductDto>>
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;

        public GetProductItemRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<ProductDto>> Handle(GetProductItemRequest request, CancellationToken cancellationToken)
        {
            var respone = new BaseResponse<ProductDto>();

            var item = await _productRepository.GetAsync(request.Id);
            if (item == null)
            {
                respone.Success = false;
                respone.Errors = new List<string>() { "item not found" };
            }
            else
            {
                respone.Success = true;
                respone.Data = _mapper.Map<ProductDto>(item);
            }

            return respone;
        }
    }
}
