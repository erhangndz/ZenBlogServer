﻿using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Categories.Results;

namespace ZenBlog.Application.Features.Categories.Queries
{
    public record GetCategoryByIdQuery(Guid Id) : IRequest<BaseResult<GetCategoryByIdQueryResult>>;

}
