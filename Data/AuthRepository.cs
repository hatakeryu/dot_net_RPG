using System.Threading.Tasks;
using dot_net_RPG.Models;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
  public class AuthRepository : IAuthRepository
  {
    private readonly DataContext _context;
    public AuthRepository(DataContext context)
    {
      _context = context;
    }
    public async Task<ServiceResponse<string>> Login(string username, string password)
    {
      throw new System.NotImplementedException();
    }

    public async Task<ServiceResponse<int>> Register(User user, string password)
    {
      ServiceResponse<int> response = new ServiceResponse<int>();
      if(await UserExists(user.Username)){
        response.Sucess = false;
        response.Message = "User already exists.";
        return response;
      }

      CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
      user.PasswordHash = passwordHash;
      user.PassWordSalt = passwordSalt;

      await _context.Users.AddAsync(user);
      await _context.SaveChangesAsync();
      response.Data = user.Id;
      return response;
    }

    public async Task<bool> UserExists(string username)
    {
      if (await _context.Users.AnyAsync(x => x.Username.ToLower() == username.ToLower()))
      {
        return true;
      }
      return false;
    }
    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
      using (var hmac = new System.Security.Cryptography.HMACSHA512())
      {
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
      }
    }
  }
}