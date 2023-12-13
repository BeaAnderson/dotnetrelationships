using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace relationships.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Backpack Backpack { get; set; }
        public List<Weapon> Weapons { get; set; }
        public List<Faction> Factions { get; set; }


        public void addWeapon(Weapon weapon)
        {
            Weapons.Add(weapon);
        }

        public void addFaction(Faction faction)
        {
            Factions.Add(faction);
        }


    }
}