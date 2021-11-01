using Application.Core;
using Application.Interfaces;
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
            private readonly IUserAccessor _userAccessor;

            public QueryHandler(DataContext dataContext, IMapper mapper, IUserAccessor userAccessor)
            {
                _dataContext = dataContext;
                _mapper = mapper;
                _userAccessor = userAccessor;
            }
            public async Task<Result<ActivityDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await _dataContext.Activities
                .ProjectTo<ActivityDto>(_mapper.ConfigurationProvider,
                 new { currentUsername = _userAccessor.GetUsername() })
                .FirstOrDefaultAsync(x => x.Id == request.Id);

                return Result<ActivityDto>.Success(activity);
            }
        }
    }
}
