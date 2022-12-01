using AutoMapper;
using MediatR;
using ProductMicroservice.Application.Contracts;
using ProductMicroservice.Application.CQRS.Requests.Queries;
using ProductMicroservice.Application.DTOs;

namespace ProductMicroservice.Application.CQRS.Handlers.Queries
{
    public class GetAllProductsRequestHandler : IRequestHandler<GetAllProductsRequest, BaseResponse<List<ProductDto>>>
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;

        public GetAllProductsRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<ProductDto>>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            var respone = new BaseResponse<List<ProductDto>>();
            var items = await _productRepository.GetAllAsync();

            respone.Success = true;
            respone.Data = _mapper.Map<List<ProductDto>>(items);
            
            return respone;
        }
    }
}
