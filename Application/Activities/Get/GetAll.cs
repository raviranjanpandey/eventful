using Application.Core;
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
        public GetAllHandler(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<Result<List<ActivityDto>>> Handle(GetAll request, CancellationToken cancellationToken)
        {
            var activities = await _dataContext.Activities
                    .ProjectTo<ActivityDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            return Result<List<ActivityDto>>.Success(activities);
        }
    }
}
