using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Messages.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Handlers
{
    public class UpdateMessageCommandHandler : IRequestHandler<UpdateMessageCommand, BaseResult<object>>
    {
        private readonly IRepository<Message> _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateMessageCommandHandler(IRepository<Message> repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResult<object>> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
        {
            var message = await _repository.GetByIdAsync(request.Id);
            if (message == null)
            {
                return BaseResult<object>.NotFound("Message not found");
            }
            message = _mapper.Map(request, message);
            _repository.Update(message);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Message Updated");
        }
    }
  
}
