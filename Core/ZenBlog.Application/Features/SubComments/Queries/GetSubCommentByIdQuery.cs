﻿using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.SubComments.Result;

namespace ZenBlog.Application.Features.SubComments.Queries
{
    public record GetSubCommentByIdQuery(Guid Id) : IRequest<BaseResult<GetSubCommentByIdQueryResult>>
    {
    }
}
