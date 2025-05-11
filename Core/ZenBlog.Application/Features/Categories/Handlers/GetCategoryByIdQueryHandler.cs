using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Categories.Queries;
using ZenBlog.Application.Features.Categories.Results;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Categories.Handlers
{
    public class GetCategoryByIdQueryHandler(IRepository<Category> repository,IMapper mapper) : IRequestHandler<GetCategoryByIdQuery, BaseResult<GetCategoryByIdQueryResult>>
    {
        public async Task<BaseResult<GetCategoryByIdQueryResult>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await repository.GetByIdAsync(request.Id);
            if (category == null) 
            {
                return BaseResult<GetCategoryByIdQueryResult>.NotFound("Category Not Found");
            }

            var response = mapper.Map<GetCategoryByIdQueryResult>(category);

            return BaseResult<GetCategoryByIdQueryResult>.Success(response);

        }
    }
}
