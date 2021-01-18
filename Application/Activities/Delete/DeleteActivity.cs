using Application.Core;
using MediatR;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities.Delete
{
    public class DeleteActivity
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _dataContext;
            public CommandHandler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _dataContext.Activities.FindAsync(request.Id);
                _dataContext.Remove(activity);
                var result = await _dataContext.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to delete.");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
