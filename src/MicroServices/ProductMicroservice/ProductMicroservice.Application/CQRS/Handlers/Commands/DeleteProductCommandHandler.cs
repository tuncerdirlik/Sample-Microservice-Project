using AutoMapper;
using MediatR;
using ProductMicroservice.Application.Contracts;
using ProductMicroservice.Application.CQRS.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Application.CQRS.Handlers.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var item = await _unitOfWork.ProductRepository.GetAsync(request.Id);
            if (item == null)
            {
                throw new Exception("Product not found");
            }

            await _unitOfWork.ProductRepository.DeleteAsync(item);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
