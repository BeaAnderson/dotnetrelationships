using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.VisualBasic;
using relationships.Data;
using relationships.DTOs;
using relationships.Models;

namespace relationshipsRefactor.Mapper
{
    public class CharacterMapper : IMapper
    {
        public DataContext _context { get; set; }

        public CharacterMapper(DataContext context)
        {
            _context = context;
        }

        public Character ToEntity(CharacterCreateDto characterDto)
        {
            var character = new Character();
            character.Name = characterDto.Name;

            Backpack backpack;

            var characterDtoBackpack = _context.Backpacks.FirstOrDefault(b => b.Description == characterDto.Backpack.Description);

            if (characterDtoBackpack != null)
            {
                backpack = characterDtoBackpack;
            }
            else
            {
                backpack = new Backpack { Description = characterDto.Backpack.Description, Character = character };
            }

            List<Weapon> updateWeapons = new List<Weapon>();

            foreach (var weapon in characterDto.Weapons)
            {
                var characterDtoWeapon = _context.Weapons.FirstOrDefault(w => w.Name == weapon.Name);
                if (characterDtoWeapon != null)
                {
                    updateWeapons.Add(characterDtoWeapon);
                }
                else
                {
                    updateWeapons.Add(new Weapon { Name = weapon.Name });
                }
            }

            List<Faction> updateFactions = new List<Faction>();

            foreach (var faction in characterDto.Factions)
            {
                var characterDtofaction = _context.Factions.FirstOrDefault(f => f.Name == faction.Name);
                if (characterDtofaction != null)
                {
                    updateFactions.Add(characterDtofaction);
                }
                else
                {
                    updateFactions.Add(new Faction { Name = faction.Name });
                }
            }

            character.Backpack = backpack;
            character.Weapons = updateWeapons;
            character.Factions = updateFactions;

            return character;
        }
    }
}