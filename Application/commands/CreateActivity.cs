using System;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities.commands;

public class CreateActivity
{
    public class commands : IRequest<string>
    {
        public required Activity Activity { get; set; }
    }

    public class Handler(AppDbcontext context) : IRequestHandler<commands, string>
    {
        public async Task<string> Handle(commands request, CancellationToken cancellationToken)
        {
            context.Activities.Add(request.Activity);

            await context.SaveChangesAsync(cancellationToken);

            return request.Activity.Id;
        }
        
    }
}
