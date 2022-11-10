using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_prac.Services.CharacterServices;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_prac.Controllers
{

    [ApiController] // Used to serve automatic HTTP responses such as status code 404 
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public ActionResult<List<Character>> Get()
        {
            return Ok(_characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public ActionResult<Character> GetSingle(int id)
        {
            return Ok(_characterService.GetCharacterById(id));
        }

        [HttpPost]
        public ActionResult<List<Character>> AddCharacter(Character newCharacter)
        {
            return Ok(_characterService.AddSingleCharacter(newCharacter));
        }
    }


} 
