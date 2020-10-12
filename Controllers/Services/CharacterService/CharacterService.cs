using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using dot_net_RPG.Models;
using Dtos.Character;
using Microsoft.EntityFrameworkCore;

namespace dot_net_RPG.Controllers.Services.CharacterService
{
  public class CharacterService : ICharacterService
  { 
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public CharacterService(IMapper mapper, DataContext context)
    {
      
      _context = context;
      _mapper = mapper;
    }
    public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
    {
      ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
      Character character = _mapper.Map<Character>(newCharacter);
      
      await _context.Characters.AddAsync(character);
      await _context.SaveChangesAsync();

      serviceResponse.Data = (_context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
      return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
    {
      ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
      try
      {

        Character character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
        _context.Characters.Remove(character); 

        await _context.SaveChangesAsync();

        serviceResponse.Data = (_context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
      }
      catch (Exception ex)
      {
        serviceResponse.Sucess = false;
        serviceResponse.Message = ex.Message;
      }

      return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
    {
      ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
      List<Character> dbCharacters = await _context.Characters.ToListAsync();
      serviceResponse.Data = (dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
      return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
    {
      ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
      Character dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
      serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
      return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
    {
      ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
      try
      {

        // Character character = characters.FirstOrDefault(c => c.Id == updateCharacter.Id);
        Character character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == updateCharacter.Id);

        character.Name = updateCharacter.Name;
        character.Class = updateCharacter.Class;
        character.Defense = updateCharacter.Defense;
        character.HitPoints = updateCharacter.HitPoints;
        character.Intelligence = updateCharacter.Intelligence;
        character.Strength = updateCharacter.Strength;

        _context.Characters.Update(character);
        await _context.SaveChangesAsync();

        serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
      }
      catch (Exception ex)
      {
        serviceResponse.Sucess = false;
        serviceResponse.Message = ex.Message;
      }

      return serviceResponse;
    }
  }
}