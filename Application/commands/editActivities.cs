using System;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.commands;

public class editActivities
{
    public class commands : IRequest
    {
        public required Activity Activity { get; set; }
    }
    public class Handler(AppDbcontext context, IMapper mapper) : IRequestHandler<commands>
    {
        public async Task Handle(commands request, CancellationToken cancellationToken)
        {
            var activity = await context.Activities
            .FindAsync([request.Activity.Id], cancellationToken)
                ?? throw new Exception("cannot fiind activity");
            mapper.Map(request.Activity, activity);

            await context.SaveChangesAsync(cancellationToken);
        }
    }
    
}
