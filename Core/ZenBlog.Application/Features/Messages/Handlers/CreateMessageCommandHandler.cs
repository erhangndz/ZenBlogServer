using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Messages.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Handlers
{
    public class CreateMessageCommandHandler(IRepository<Message> repository,IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<CreateMessageCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
           var message = mapper.Map<Message>(request);
           await repository.CreateAsync(message);
           await unitOfWork.SaveChangesAsync();
           return BaseResult<object>.Success(message);
        }
    }
}
