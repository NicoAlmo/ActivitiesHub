using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsHub.Application.Events.Commands;
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
    [ProducesResponseType(typeof(IReadOnlyList<Event>),StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<Event>>> GetEventsAsync()
    {
        return  await Mediator.Send(new GetEventList.Query());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Event),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Event),StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Event>> GetEventDetailAsync(string id)
    {
        return await Mediator.Send(new GetEventDetails.Query{Id=id});
    }

   [HttpPost]
   [ProducesResponseType(typeof(string),StatusCodes.Status200OK)]
   [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]

   public async Task<ActionResult<string>> CreateEventAsync (Event @event)
    {
        return await Mediator.Send(new CreateEvent.Command {Event = @event });
    }
}   
