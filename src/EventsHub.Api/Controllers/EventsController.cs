using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsHub.Application.Events.Queries;
using EventsHub.Domain;
using EventsHub.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Validation;

namespace EventsHub.Api.Controllers;
public class EventsController : EventsHubBaseController
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Event>>> GetEventsAsync()
    {
        return  await Mediator.Send(new GetEventList.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Event>> GetEventDetailAsync(string id)
    {
        return await Mediator.Send(new GetEventDetails.Query{Id=id});
    }
}
