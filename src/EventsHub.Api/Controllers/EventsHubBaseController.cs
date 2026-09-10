using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventsHub.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class EventsHubBaseController : ControllerBase {}
