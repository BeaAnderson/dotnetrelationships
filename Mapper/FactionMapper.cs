using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using relationships.Data;
using relationships.DTOs;
using relationships.Models;

namespace relationshipsRefactor.Mapper
{
    public class FactionMapper : IFactionMapper
    {
        public DataContext _context { get; set; }

        public FactionMapper(DataContext context)
        {
            _context = context;
        }

        public Faction ToEntity(FactionCreateDto factionCreateDto)
        {

            var faction = new Faction();

            Character character;
            faction.Name = factionCreateDto.Name;

            if (factionCreateDto.characters != null)
            {
                faction.Characters = new List<Character>();
                foreach (var characterName in factionCreateDto.characters)
                {
                    var dbCharacter = _context.Characters.FirstOrDefault(c => c.Name == characterName);
                    if (dbCharacter != null)
                    {
                        character = dbCharacter;
                        Console.WriteLine(dbCharacter.ToString());

                        //create method in faction to add character and call that.
                        faction.AddCharacter(character);
                    }
                    else
                    {
                        var tobeadded = new Character();
                        tobeadded.Name = characterName;

                        //create method in faction to add character and call that.
                        faction.AddCharacter(tobeadded);
                    }
                }
            }

            return faction;
        }
    }
}