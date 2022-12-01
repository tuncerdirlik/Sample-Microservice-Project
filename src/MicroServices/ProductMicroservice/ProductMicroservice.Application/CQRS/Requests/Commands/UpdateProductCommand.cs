using MediatR;
using ProductMicroservice.Application.DTOs;

namespace ProductMicroservice.Application.CQRS.Requests.Commands
{
    public class UpdateProductCommand : IRequest<BaseResponse<ProductDto>>
    {
        public ProductDto ProductDto { get; set; }
    }
}
