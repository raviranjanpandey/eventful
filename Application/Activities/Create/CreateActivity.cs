using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities.Save
{
    public class CreateActivity
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Activity Activity { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Activity).SetValidator(new CreateActivityValidator());
            }
        }

        public class CommandHandler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _dataContext;
            private readonly IMapper _mapper;
            private readonly IUserAccessor _userAccessor;
            public CommandHandler(DataContext dataContext, IMapper mapper, IUserAccessor userAccessor)
            {
                _dataContext = dataContext;
                _mapper = mapper;
                _userAccessor = userAccessor;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _dataContext.Users.FirstOrDefaultAsync(x =>
                   x.UserName == _userAccessor.GetUsername());

                var attendee = new ActivityAttendee
                {
                    AppUser = user,
                    Activity = request.Activity,
                    IsHost = true
                };

                request.Activity.Attendees.Add(attendee);

                _dataContext.Activities.Add(request.Activity);

                var result = await _dataContext.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create activity");

                return Result<Unit>.Success(Unit.Value);
            }

        }
    }
}
