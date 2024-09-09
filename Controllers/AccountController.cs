using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{
    private readonly IAccountRepository _repository;

    public AccountsController(IAccountRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var accounts = await _repository.GetAllAccountsAsync();
        return Ok(accounts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var account = await _repository.GetAccountByIdAsync(id);
        if (account == null)
        {
            return NotFound();
        }
        return Ok(account);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Account account)
    {
        await _repository.AddAccountAsync(account);
        return CreatedAtAction(nameof(Get), new { id = account.Id }, account);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAccountAsync(id);
        return NoContent();
    }
}
