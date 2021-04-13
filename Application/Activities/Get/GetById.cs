using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities.Get
{
    public class GetById
    {
        public class Query : IRequest<Result<ActivityDto>>
        {
            public Guid Id { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Result<ActivityDto>>
        {
            private readonly DataContext _dataContext;
            private readonly IMapper _mapper;
            public QueryHandler(DataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }
            public async Task<Result<ActivityDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await _dataContext.Activities
                    .ProjectTo<ActivityDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);
                return Result<ActivityDto>.Success(activity);
            }
        }
    }
}
