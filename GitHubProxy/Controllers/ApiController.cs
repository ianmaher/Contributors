using GitHubProxy.Application.Features.GetContributorList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GitHubProxy.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{
    
    private readonly ILogger<ApiController> _logger;
    private readonly IMediator _mediator;

    public ApiController(ILogger<ApiController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [Route("v1/{owner}/{repo}")]
    [HttpGet()]
    public async Task<IActionResult> Get([FromRoute] string owner, string repo)
    {
        try
        {
            var response = await _mediator.Send(new GetContributorListQuery() { Owner = owner, Repo = repo });
            return Ok(response);

        }
        catch ( Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest();
        }
    }
}

