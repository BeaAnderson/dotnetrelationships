using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using relationships.Data;
using relationships.DTOs;
using relationships.Models;
using relationshipsRefactor.Mapper;
using relationshipsRefactor.Services;

namespace relationships.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {

        private readonly ICharacterService _service;
        private readonly IMapper _mapper;

        public CharacterController(ICharacterService characterService, IMapper mapper)
        {
            _service = characterService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacterById(int id)
        {
            return Ok(await _service.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> CreateCharacter(CharacterCreateDto request)
        {
            return Ok(await _service.CreateCharacter(request));
        }

        [HttpGet]
        public async Task<ActionResult<List<Character>>> GetAllCharacters()
        {
            return Ok(await _service.GetAllCharacters());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var character = await _service.GetCharacterById(id);

            if (character == null)
            {
                return NotFound();
            }
            await _service.DeleteCharacter(character);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCharacter(CharacterCreateDto chardto, int id)
        {
            await _service.Update(chardto, id);
            return Ok();
        }
    }
}