using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsHub.Domain;
using EventsHub.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Validation;

namespace EventsHub.Api.Controllers;
public class EventsController(AppDbContext context) : EventsHubBaseController
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Event>>> GetEventsAsync()
    {
        return  await context.Events.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Event>> GetEventDetailAsync(string id)
    {
        var result = await context.Events.FindAsync(id);

        if (result == null ) return NotFound ("The event was not found");

        return result;
    }
}
