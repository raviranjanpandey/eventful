using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities.Get
{
    public class GetAll : IRequest<Result<List<ActivityDto>>> { }

    public class GetAllHandler : IRequestHandler<GetAll, Result<List<ActivityDto>>>
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;

        public GetAllHandler(DataContext dataContext, IMapper mapper, IUserAccessor userAccessor)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }
        public async Task<Result<List<ActivityDto>>> Handle(GetAll request, CancellationToken cancellationToken)
        {
            var activities = await _dataContext.Activities
                    .ProjectTo<ActivityDto>(_mapper.ConfigurationProvider, 
                     new { currentUsername = _userAccessor.GetUsername()})
                    .ToListAsync(cancellationToken);

            return Result<List<ActivityDto>>.Success(activities);
        }
    }
}
