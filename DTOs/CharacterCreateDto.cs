using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using relationships.Models;

namespace relationships.DTOs
{
    public class CharacterCreateDto
    {
        public string Name { get; set; }
        public BackpackCreateDto Backpack { get; set; }
        public List<WeaponCreateDto> Weapons { get; set; }
        public List<FactionCreateDto> Factions { get; set; }
    }
}