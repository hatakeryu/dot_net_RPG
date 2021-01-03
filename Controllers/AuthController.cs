using System.Threading.Tasks;
using Data;
using dot_net_RPG.Models;
using Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AuthController : ControllerBase
  {
    private readonly IAuthRepository _autoRepo;
    public AuthController(IAuthRepository authRepo)
    {
      _autoRepo = authRepo;
    }

    public async Task<IActionResult> Register(UserRegisterDto request)
    {
      ServiceResponse<int> response = await _autoRepo.Register(
        new Models.User { Username = request.Username }, request.Password
      );

      if (!response.Sucess)
      {
        return BadRequest(response);
      }

      return Ok(response);
    }
  }
}
