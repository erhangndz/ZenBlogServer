using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Messages.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Handlers
{
    public class RemoveMessageCommandHandler : IRequestHandler<RemoveMessageCommand, BaseResult<object>>
    {
        private readonly IRepository<Message> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public RemoveMessageCommandHandler(IRepository<Message> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResult<object>> Handle(RemoveMessageCommand request, CancellationToken cancellationToken)
        {
            var message = await _repository.GetByIdAsync(request.Id);
            if (message == null)
            {
                return BaseResult<object>.NotFound("Message not found");
            }
            _repository.Delete(message);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Message Deleted");
        }
    }
   
}
