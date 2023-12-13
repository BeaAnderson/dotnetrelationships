using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using relationships.DTOs;
using relationships.Models;
using relationshipsRefactor.Mapper;
using relationshipsRefactor.Services;

namespace relationshipsRefactor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FactionController : ControllerBase
    {
        private readonly IFactionService _service;
        private readonly IFactionMapper _mapper;
        private readonly ILogger<FactionController> _logger;

        public FactionController(IFactionService service, IFactionMapper mapper, ILogger<FactionController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("/faction/{id}")]
        public async Task<ActionResult<Faction>> GetFactionById(int id)
        {
            return Ok(await _service.GetFactionById(id));
        }

        [HttpPost]
        public async Task<ActionResult<List<Weapon>>> CreateFaction(FactionCreateDto factionCreateDto)
        {
            return Ok(await _service.CreateFaction(factionCreateDto));
        }

        [HttpGet]
        public async Task<ActionResult<List<Faction>>> GetAllFactions()
        {
            return Ok(await _service.GetAllFactions());
        }

        [HttpDelete("{id}")]

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFaction(FactionCreateDto factionDto, int id)
        {
            await _service.Update(factionDto, id);
            return Ok();
        }

    }
}