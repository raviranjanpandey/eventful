using Application.Core;
using AutoMapper;
using Domain.Models;
using FluentValidation;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities.Update
{
    public class UpdateActivity
    {
        public class Command : IRequest<Result<bool>>
        {
            public Activity Activity { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Activity).SetValidator(new UpdateActivityValidator());
            }
        }

        public class CommandHandler : IRequestHandler<Command, Result<bool>>
        {
            private readonly DataContext _dataContext;
            private readonly IMapper _mapper;
            public CommandHandler(DataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _dataContext.Activities.FindAsync(request.Activity.Id);

                if (activity == null) return Result<bool>.Failure("No Records to update.");

                _mapper.Map(request.Activity, activity);

                if (_dataContext.ChangeTracker.HasChanges())
                {
                    var result = await _dataContext.SaveChangesAsync() > 0;
                    return Result<bool>.Success(result);
                }
                else
                {
                    return Result<bool>.NoChangesDetected("No Changes to update.");
                }             
            }
        }
    }
}
