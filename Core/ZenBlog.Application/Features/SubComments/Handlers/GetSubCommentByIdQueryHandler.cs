using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.SubComments.Queries;
using ZenBlog.Application.Features.SubComments.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Handlers
{
    public class GetSubCommentByIdQueryHandler(IRepository<SubComment> _repository, IMapper _mapper) : IRequestHandler<GetSubCommentByIdQuery, BaseResult<GetSubCommentByIdQueryResult>>
    {
        public async Task<BaseResult<GetSubCommentByIdQueryResult>> Handle(GetSubCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value is null)
            {
                return BaseResult<GetSubCommentByIdQueryResult>.NotFound("SubComment Not Found");
            }

            var subComment = _mapper.Map<GetSubCommentByIdQueryResult>(value);
            return BaseResult<GetSubCommentByIdQueryResult>.Success(subComment);
        }
    }
}
