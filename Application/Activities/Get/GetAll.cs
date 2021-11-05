using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities.Get
{
    public class GetAll : IRequest<Result<PagedList<ActivityDto>>>
    {
        public PagingParams Params { get; set; }
    }

    public class GetAllHandler : IRequestHandler<GetAll, Result<PagedList<ActivityDto>>>
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
        public async Task<Result<PagedList<ActivityDto>>> Handle(GetAll request, CancellationToken cancellationToken)
        {
            var query = _dataContext.Activities
                    .OrderBy(d => d.Date)
                    .ProjectTo<ActivityDto>(_mapper.ConfigurationProvider,
                     new { currentUsername = _userAccessor.GetUsername() })
                    .AsQueryable();

            return Result<PagedList<ActivityDto>>.Success(
                await PagedList<ActivityDto>.CreateAsync(query, request.Params.PageNumber,
                request.Params.PageSize));
        }
    }
}
