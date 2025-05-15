using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.SubComments.Queries;
using ZenBlog.Application.Features.SubComments.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Handlers
{
    public class GetSubCommentsQueryHandler(IRepository<SubComment> _repository,IMapper _mapper) : IRequestHandler<GetSubCommentsQuery, BaseResult<List<GetSubCommentsQueryResult>>>
    {
        public async Task<BaseResult<List<GetSubCommentsQueryResult>>> Handle(GetSubCommentsQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var subComments = _mapper.Map<List<GetSubCommentsQueryResult>>(values);
            return BaseResult<List<GetSubCommentsQueryResult>>.Success(subComments);
        }
    }
}
