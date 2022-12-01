using MediatR;

namespace CustomerMicroService.Application.CQRS.Requests.Commands
{
    public class DeleteCustomerCommand : IRequest
    {
        public int Id { get; set; }
    }
}
