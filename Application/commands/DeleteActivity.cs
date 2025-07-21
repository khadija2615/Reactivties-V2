using System;
using MediatR;
using Persistence;

namespace Application.commands;

public class DeleteActivity
{
    public class commands : IRequest
    {
        public required string Id { get; set; }
    }
    public class Handler(AppDbcontext context) : IRequestHandler<commands>
    {
        public async Task Handle(commands request, CancellationToken cancellationToken)
        {
            var activity = await context.Activities
              .FindAsync([request.Id], cancellationToken)
                  ?? throw new Exception("cannot fiind activity");
            context.Remove(activity);
            await context.SaveChangesAsync(cancellationToken);
        }
        
    }
}

public class async
{
}