using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface IAccountRepository
{
    Task<List<Account>> GetAllAccountsAsync();
    Task<Account> GetAccountByIdAsync(int id);
    Task AddAccountAsync(Account account);
    Task DeleteAccountAsync(int id);
}

public interface IUserRepository
{
    Task<List<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(string id);
    Task UpdateUserAsync(User user);
    Task AddUserAsync(User user);
    Task DeleteUserAsync(string id);
}

public class InMemoryAccountRepository : IAccountRepository
{
    private readonly List<Account> _accounts = new List<Account>
    {
        new Account { Id = 1, Name = "Cuenta Corriente", CedulaUsuario = "802-80-2354", Balance = "$460484.36" },
        new Account { Id = 2, Name = "Caja de Ahorro", CedulaUsuario = "168-81-2457", Balance = "$104132.04" },
        // Agregar el resto de los datos aquí...
    };

    public Task<List<Account>> GetAllAccountsAsync() => Task.FromResult(_accounts);

    public Task<Account> GetAccountByIdAsync(int id) => Task.FromResult(_accounts.FirstOrDefault(a => a.Id == id));

    public Task AddAccountAsync(Account account)
    {
        _accounts.Add(account);
        return Task.CompletedTask;
    }

    public Task DeleteAccountAsync(int id)
    {
        var account = _accounts.FirstOrDefault(a => a.Id == id);
        if (account != null)
        {
            _accounts.Remove(account);
        }
        return Task.CompletedTask;
    }
}

public class InMemoryUserRepository : IUserRepository
{
    private readonly List<User> _users = new List<User>
    {
        new User { Id = "802-80-2354", Name = "Marylou", Lastname = "Baum", Email = "mbaum0@blogtalkradio.com" },
        new User { Id = "168-81-2457", Name = "Dulcea", Lastname = "Davana", Email = "ddavana1@tumblr.com" },
        // Agregar el resto de los datos aquí...
    };

    public Task<List<User>> GetAllUsersAsync() => Task.FromResult(_users);

    public Task<User> GetUserByIdAsync(string id) => Task.FromResult(_users.FirstOrDefault(u => u.Id == id));

    public Task UpdateUserAsync(User user)
    {
        var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
        if (existingUser != null)
        {
            existingUser.Name = user.Name;
            existingUser.Lastname = user.Lastname;
            existingUser.Email = user.Email;
        }
        return Task.CompletedTask;
    }

    public Task AddUserAsync(User user)
    {
        _users.Add(user);
        return Task.CompletedTask;
    }

    public Task DeleteUserAsync(string id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
            _users.Remove(user);
        }
        return Task.CompletedTask;
    }
}
