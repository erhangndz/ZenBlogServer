using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.ContactInfos.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.ContactInfos.Handlers
{
    public class CreateContactInfoCommandHandler(IRepository<ContactInfo> repository, IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<CreateContactInfoCommand, BaseResult<object>>
    {
       

        public async Task<BaseResult<object>> Handle(CreateContactInfoCommand request, CancellationToken cancellationToken)
        {
            var contactInfo = mapper.Map<ContactInfo>(request);
            await repository.CreateAsync(contactInfo);
            await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(contactInfo);
        }
    }
   
}
