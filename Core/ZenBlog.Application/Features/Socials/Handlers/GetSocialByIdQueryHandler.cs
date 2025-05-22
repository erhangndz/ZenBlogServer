using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Socials.Queries;
using ZenBlog.Application.Features.Socials.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Socials.Handlers
{
    internal class GetSocialByIdQueryHandler(IRepository<Social> repository, IMapper mapper) : IRequestHandler<GetSocialByIdQuery, BaseResult<GetSocialByIdQueryResult>>
    {
        public async Task<BaseResult<GetSocialByIdQueryResult>> Handle(GetSocialByIdQuery request, CancellationToken cancellationToken)
        {
            // Get the social by ID
            var social = await repository.GetByIdAsync(request.Id);
            if (social == null)
            {
                return BaseResult<GetSocialByIdQueryResult>.Fail("Social not found.");
            }
            //mapping the social to the result object
            var socialResult = mapper.Map<GetSocialByIdQueryResult>(social);
            return BaseResult<GetSocialByIdQueryResult>.Success(socialResult);

        }
    }
}
