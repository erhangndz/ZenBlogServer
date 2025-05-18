using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Messages.Queries;
using ZenBlog.Application.Features.Messages.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Handlers
{
    public class GetMessagesQueryHandler : IRequestHandler<GetMessagesQuery, BaseResult<List<GetMessagesQueryResult>>>
    {
        private readonly IRepository<Message> _repository;
        private readonly IMapper _mapper;
        public GetMessagesQueryHandler(IRepository<Message> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BaseResult<List<GetMessagesQueryResult>>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
        {
            var messages = await _repository.GetAllAsync();
            var result = _mapper.Map<List<GetMessagesQueryResult>>(messages);
            return BaseResult<List<GetMessagesQueryResult>>.Success(result);
        }
    }
}
