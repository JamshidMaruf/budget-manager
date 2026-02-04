using BudgetManager.Application.Incomes.Commands.CreateIncome;
using BudgetManager.Application.Incomes.Commands.DeleteIncome;
using BudgetManager.Application.Incomes.Commands.UpdateIncome;
using BudgetManager.Application.Incomes.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BudgetManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IncomesController(ISender sender) : ControllerBase
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
    public async Task<IActionResult> Create([FromBody] CreateIncomeCommand command)
    {
        await sender.Send(command);
        return Created();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateIncomeCommand command)
    {
        if (id != command.Id)
            return BadRequest("Id mismatch");
        
        await sender.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await sender.Send(new DeleteIncomeCommand(id));
        return NoContent();
    }
}

