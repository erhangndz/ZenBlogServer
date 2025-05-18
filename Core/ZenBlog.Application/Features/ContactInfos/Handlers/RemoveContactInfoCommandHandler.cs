using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.ContactInfos.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.ContactInfos.Handlers
{
    public class RemoveContactInfoCommandHandler(IRepository<ContactInfo> repository, IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<RemoveContactInfoCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveContactInfoCommand request, CancellationToken cancellationToken)
        {
            // Get the contact info by ID
            var contactInfo = await repository.GetByIdAsync(request.Id);
            if (contactInfo == null)
            {
                return BaseResult<object>.Fail("Contact info not found.");
            }
            // Remove the contact info
            repository.Delete(contactInfo);
            await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Contact Info Removed");
        }
    }
  
}
