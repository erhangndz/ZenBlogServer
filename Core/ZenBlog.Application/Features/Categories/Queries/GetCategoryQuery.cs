using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Categories.Result;

namespace ZenBlog.Application.Features.Categories.Queries
{
    public class GetCategoryQuery: IRequest<BaseResult<List<GetCategoryQueryResult>>>
    {
    }
}
