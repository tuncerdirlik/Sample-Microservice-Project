using UI.Api.Models;

namespace UI.Api.Services.Contracts
{
    public interface ICustomerService
    {
        Task<BaseResponse<CustomerVM>> GetById(int customerId);

        Task<BaseResponse<List<CustomerVM>>> GetAllAsync();

        Task<BaseResponse<CustomerVM>> Create(CustomerVM customer);
    }
}
