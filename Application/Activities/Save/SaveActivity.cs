using Application.Core;
using AutoMapper;
using Domain.Models;
using FluentValidation;
using MediatR;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities.Save
{
    public class SaveActivity
    {
        public class Command : IRequest<Result<Guid>>
        {
            public Activity Activity { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Activity).SetValidator(new ActivityValidator());
            }
        }

        public class CommandHandler : IRequestHandler<Command, Result<Guid>>
        {
            private readonly DataContext _dataContext;
            private readonly IMapper _mapper;
            public CommandHandler(DataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }
            public async Task<Result<Guid>> Handle(Command request, CancellationToken cancellationToken)
            {
                if (request.Activity.Id.Equals(Guid.Empty))
                {
                    _dataContext.Activities.Add(request.Activity);
                }
                else
                {
                    var activity = await _dataContext.Activities.FindAsync(request.Activity.Id);

                    if (activity == null) return null;

                    _mapper.Map(request.Activity, activity);
                }

                var result = await _dataContext.SaveChangesAsync() > 0;
                if (!result) return Result<Guid>.Failure("Failed to update.");
                return Result<Guid>.Success(request.Activity.Id);
            }
        }
    }
}
