using MediatR;
using ProductMicroservice.Application.DTOs;

namespace ProductMicroservice.Application.CQRS.Requests.Commands
{
    public class CreateProductCommand : IRequest<BaseResponse<ProductDto>>
    {
        public CreateProductDto CreateProductDto { get; set; }
    }
}
