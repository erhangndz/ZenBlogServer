using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.ContactInfos.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.ContactInfos.Handlers
{
    public class UpdateContactInfoCommandHandler(IRepository<ContactInfo> repository, IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<UpdateContactInfoCommand, BaseResult<object>>
    {
       

        public async Task<BaseResult<object>> Handle(UpdateContactInfoCommand request, CancellationToken cancellationToken)
        {
            var contactInfo = await repository.GetByIdAsync(request.Id);
            if (contactInfo == null)
            {
                return BaseResult<object>.Fail("Contact info not found.");
            }
            mapper.Map(request, contactInfo);
            repository.Update(contactInfo);
            await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Contact Info Updated");
        }
    }
  
}
