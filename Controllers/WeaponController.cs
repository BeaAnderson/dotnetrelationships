using System;
using System.Collections.Generic;
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
    public class WeaponController : ControllerBase
    {
        private readonly IWeaponService _service;

        public WeaponController(IWeaponService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Weapon>> GetWeaponById(int id)
        {
            return Ok(await _service.GetWeaponById(id));
        }

        [HttpPost]
        public async Task<ActionResult<List<Weapon>>> CreateWeapon(WeaponCreateDto weaponCreateDto)
        {
            return Ok(await _service.CreateWeapon(weaponCreateDto));
        }

        [HttpGet]
        public async Task<ActionResult<List<Weapon>>> GetAllWeapons()
        {
            return Ok(await _service.GetAllWeapons());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeapon(int id)
        {
            var weapon = await _service.GetWeaponById(id);
            if (weapon == null)
            {
                return NotFound();
            }
            await _service.DeleteWeapon(weapon);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCharacter(WeaponCreateDto weaponCreateDto, int id)
        {
            await _service.Update(weaponCreateDto, id);
            return Ok();
        }
    }
}