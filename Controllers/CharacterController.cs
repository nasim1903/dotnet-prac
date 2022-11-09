using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_prac.Controllers
{
    
    [ApiController] // Used to serve automatic HTTP responses such as status code 404 
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private static List<Character> characters = new List<Character> {
            new Character("Fredo"),
            new Character("Sam")
        };

        [HttpGet]
        public ActionResult<List<Character>> Get()
        {
            return Ok(characters);
        }
         
        [HttpGet("{id}")]
        public ActionResult<Character> GetOne(int id )
        {
            return Ok(characters.FirstOrDefault(c => c.id == id));
        }


    } 
}