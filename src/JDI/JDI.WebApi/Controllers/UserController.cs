using JDI.Models.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JDI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDetailResponse>> GetUserDetail(int id)
    {
        var data = await _mediator.Send(new UserDetailRequest { Id = id});
        return Ok(data);
    }
}