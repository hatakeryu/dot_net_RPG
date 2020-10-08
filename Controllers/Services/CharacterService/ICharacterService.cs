using System.Collections.Generic;
using System.Threading.Tasks;
using dot_net_RPG.Models;
using Dtos.Character;

namespace dot_net_RPG.Controllers.Services.CharacterService
{
  public interface ICharacterService
  {
    Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
    Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);

    Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);

    Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter);

    Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int Id);
  }
}