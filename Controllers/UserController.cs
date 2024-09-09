using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _repository;

    public UsersController(IUserRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var users = await _repository.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("find/{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var user = await _repository.GetUserByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> Put(string id, [FromBody] User user)
    {
        if (user.Id != id)
        {
            return BadRequest();
        }

        await _repository.UpdateUserAsync(user);
        return NoContent();
    }

    [HttpPost("save")]
    public async Task<IActionResult> Post([FromBody] User user)
    {
        await _repository.AddUserAsync(user);
        return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _repository.DeleteUserAsync(id);
        return NoContent();
    }
}
