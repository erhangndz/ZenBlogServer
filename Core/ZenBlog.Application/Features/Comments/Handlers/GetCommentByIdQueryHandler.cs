using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Comments.Queries;
using ZenBlog.Application.Features.Comments.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Handlers
{
    public class GetCommentByIdQueryHandler(IRepository<Comment> _repository,IMapper _mapper) : IRequestHandler<GetCommentByIdQuery, BaseResult<GetCommentByIdQueryResult>>
    {
        public async Task<BaseResult<GetCommentByIdQueryResult>> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value is null)
            {
                return BaseResult<GetCommentByIdQueryResult>.NotFound("Comment Not Found");
            }

            var comment = _mapper.Map<GetCommentByIdQueryResult>(value);
            return BaseResult<GetCommentByIdQueryResult>.Success(comment);
        }
    }
}
