using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_prac.Data;
using dotnet_prac.Dtos.Character;
using Microsoft.EntityFrameworkCore;

namespace dotnet_prac.Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character> {
            new Character(),
            new Character {Name = "Sam" },
            new Character {Name = "Manny" }
        };
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharacterService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            characters.Add(character);
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

            try
            {
                var character = characters.First(c => c.id == id);
                characters.Remove(character);

                serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {       
            var response = new ServiceResponse<List<GetCharacterDto>>();
            var DbCharacters = await _context.Characters.ToListAsync();
            response.Data = DbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var DbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(DbCharacter);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> updateCharacter(UpdateCharacterDto updateCharacter, int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = characters.FirstOrDefault(c => c.id == id);

            try
            {
                _mapper.Map(updateCharacter, character);

                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                serviceResponse.success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}