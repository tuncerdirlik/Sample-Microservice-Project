using AutoMapper;
using CustomerMicroService.Application.Contracts;
using CustomerMicroService.Application.CQRS.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMicroService.Application.CQRS.Handlers.Commands
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var item = await _unitOfWork.CustomerRepository.GetAsync(request.Id);
            if (item == null)
            {
                throw new Exception("Customer not found");
            }

            await _unitOfWork.CustomerRepository.DeleteAsync(item);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
