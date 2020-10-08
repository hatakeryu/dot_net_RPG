using AutoMapper;
using dot_net_RPG.Models;
using Dtos.Character;

namespace dot_net_RPG
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<Character, GetCharacterDto>(); 
      CreateMap<AddCharacterDto, Character>();
    }
  }
}