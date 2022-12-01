using MediatR;
using ProductMicroservice.Application.DTOs;

namespace ProductMicroservice.Application.CQRS.Requests.Queries
{
    public class GetAllProductsRequest : IRequest<BaseResponse<List<ProductDto>>>
    {
    }
}
