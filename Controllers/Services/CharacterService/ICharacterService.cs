using System.Collections.Generic;
using System.Threading.Tasks;
using dot_net_RPG.Models;

namespace dot_net_RPG.Controllers.Services.CharacterService
{
  public interface ICharacterService
  {
    Task<ServiceResponse<List<Character>>> GetAllCharacters();
    Task<ServiceResponse<Character>> GetCharacterById(int id);

    Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter);
  }
}