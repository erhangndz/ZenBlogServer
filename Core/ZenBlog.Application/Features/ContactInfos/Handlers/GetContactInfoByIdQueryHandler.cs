using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.ContactInfos.Queries;
using ZenBlog.Application.Features.ContactInfos.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.ContactInfos.Handlers
{
    public class GetContactInfoByIdQueryHandler(IRepository<ContactInfo> repository, IMapper mapper) : IRequestHandler<GetContactInfoByIdQuery, BaseResult<GetContactInfoByIdQueryResult>>
    {
        public async Task<BaseResult<GetContactInfoByIdQueryResult>> Handle(GetContactInfoByIdQuery request, CancellationToken cancellationToken)
        {
           var contactInfo = await repository.GetByIdAsync(request.Id);
            if (contactInfo == null)
            {
                return BaseResult<GetContactInfoByIdQueryResult>.Fail("Contact info not found");
            }
            var result = mapper.Map<GetContactInfoByIdQueryResult>(contactInfo);
            return BaseResult<GetContactInfoByIdQueryResult>.Success(result);
        }
    }
  
}
