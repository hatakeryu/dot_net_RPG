using Microsoft.AspNetCore.Mvc;
using dot_net_RPG.Models;
using System.Collections.Generic;
using System.Linq;
using dot_net_RPG.Controllers.Services.CharacterService;
using System.Threading.Tasks;

namespace dot_net_RPG.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CharacterController : ControllerBase
  { 
    private readonly ICharacterService _characterService;

    public CharacterController(ICharacterService characterService)
    {
      _characterService = characterService;
    }
    /*
    GET
    */

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAction()
    {
      return Ok(await _characterService.GetAllCharacters());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingle(int id)
    {
      return Ok(await _characterService.GetCharacterById(id));
    }

    /*
      PUT
    */

    [HttpPost]
    public async Task<IActionResult> AddCharacter(Character newCharacter)
    {
      return Ok(await _characterService.AddCharacter(newCharacter));
    }
  }
}