using UI.Api.Models;

namespace UI.Api.Services.Contracts
{
    public interface IProductService
    {
        Task<BaseResponse<ProductVM>> GetById(int customerId);

        Task<BaseResponse<List<ProductVM>>> GetAllAsync();

        Task<BaseResponse<ProductVM>> Create(ProductVM customer);
    }
}
