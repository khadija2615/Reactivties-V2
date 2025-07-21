using System;
using Application.Activities.commands;
using Application.Activities.Queries;
using Application.commands;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await Mediator.Send(new GetActivityList.Query());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetail(string id)
    {
        return await Mediator.Send(new GetActivityDetails.Query { Id = id });
    }
    [HttpPost]
    public async Task<ActionResult<string>> CreateActivity(Activity activity)
    {
        return await Mediator.Send(new CreateActivity.commands { Activity = activity });
    }
    [HttpPut]
    public async Task<ActionResult> editActivities(Activity activity)
    {
        await Mediator.Send(new editActivities.commands { Activity = activity });
        return NoContent();
    }
    [HttpDelete("{id}")]

    public async Task<ActionResult> DeleteActivity(string id)
    {
        await Mediator.Send(new DeleteActivity.commands { Id = id });
        return Ok();
    }   

}

