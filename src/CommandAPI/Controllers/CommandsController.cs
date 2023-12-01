using CommandAPI.Data;
using CommandAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommandsController : ControllerBase
{
    private readonly ICommandAPIRepo _repository;
    public CommandsController(ICommandAPIRepo repository)
    {
        _repository = repository;
    }
    [HttpGet()]
    public ActionResult<IEnumerable<Command>> GetAllCommands()
    {
        var commandItems = _repository.GetAllCommands();
        return Ok(commandItems);
    }

    [HttpGet("{id}")]
    public ActionResult<Command> GetCommandById(int id)
    {
        var item = _repository.GetCommandById(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }
}