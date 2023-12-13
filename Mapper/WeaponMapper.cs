using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using relationships.Data;
using relationships.DTOs;
using relationships.Models;

namespace relationshipsRefactor.Mapper
{
    public class WeaponMapper : IWeaponMapper
    {
        public DataContext _context { get; set; }

        public WeaponMapper(DataContext context)
        {
            _context = context;
        }

        public Weapon ToEntity(WeaponCreateDto weaponCreateDto)
        {
            var weapon = new Weapon();
            weapon.Name = weaponCreateDto.Name;
            Character character;
            var weaponDtocharacter = _context.Characters.FirstOrDefault(c => c.Name == weaponCreateDto.CharacterName);

            if (weaponDtocharacter != null)
            {
                character = weaponDtocharacter;
                weapon.CharacterId = character.Id;
            }
            else
            {
                character = new Character { Name = weaponCreateDto.CharacterName };
            }
            weapon.Character = character;
            return weapon;
        }
    }
}