using MediatR;
using ProductMicroservice.Application.DTOs;

namespace ProductMicroservice.Application.CQRS.Requests.Queries
{
    public class GetProductItemRequest : IRequest<BaseResponse<ProductDto>>
    {
        public int Id { get; set; }
    }
}
