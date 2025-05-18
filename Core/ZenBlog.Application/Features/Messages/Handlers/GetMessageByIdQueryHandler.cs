using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Messages.Queries;
using ZenBlog.Application.Features.Messages.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Handlers
{
    public class GetMessageByIdQueryHandler : IRequestHandler<GetMessageByIdQuery, BaseResult<GetMessageByIdQueryResult>>
    {
        private readonly IRepository<Message> _repository;
        private readonly IMapper _mapper;
        public GetMessageByIdQueryHandler(IRepository<Message> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BaseResult<GetMessageByIdQueryResult>> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
        {
            var message = await _repository.GetByIdAsync(request.Id);
            if (message == null)
            {
                return BaseResult<GetMessageByIdQueryResult>.NotFound("Message not found");
            }
            var result = _mapper.Map<GetMessageByIdQueryResult>(message);
            return BaseResult<GetMessageByIdQueryResult>.Success(result);
        }
    }
   
}
