using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Messages.Queries;
using ZenBlog.Application.Features.Messages.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Handlers
{
    internal class GetUnreadMessagesQueryHandler(IRepository<Message> repository,IMapper mapper) : IRequestHandler<GetUnreadMessagesQuery, BaseResult<List<GetUnreadMessagesQueryResult>>>
    {
        public async Task<BaseResult<List<GetUnreadMessagesQueryResult>>> Handle(GetUnreadMessagesQuery request, CancellationToken cancellationToken)
        {
            var messages = await repository.GetAllAsync(x => x.IsRead == false);
            var mappedResult = mapper.Map<List<GetUnreadMessagesQueryResult>>(messages);
            return BaseResult<List<GetUnreadMessagesQueryResult>>.Success(mappedResult);
        }
    }
}
