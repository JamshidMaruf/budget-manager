using BudgetManager.Application.Expanses.Commands.CreateExpanse;
using BudgetManager.Application.Expanses.Commands.DeleteExpanse;
using BudgetManager.Application.Expanses.Commands.UpdateExpanse;
using BudgetManager.Application.Expanses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BudgetManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpansesController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 10)
    {
        var result = await sender.Send(new GetListQuery(pageIndex, pageSize));
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await sender.Send(new GetByIdQuery(id));
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateExpanseCommand command)
    {
        await sender.Send(command);
        return Created();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateExpanseCommand command)
    {
        if (id != command.Id)
            return BadRequest("Id mismatch");
        
        await sender.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await sender.Send(new DeleteExpanseCommand(id));
        
        if(result.IsFailure)
            return BadRequest(result.Error);
        
        return NoContent();
    }
}

