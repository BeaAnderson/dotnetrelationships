using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace relationships.Models
{
    public class Faction
    {

        private List<Character>? _characters;
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<Character>? Characters
        {
            get => this._characters;
            set => value = this._characters;
        }
        public List<string> CharacterString
        {
            get => this.toStringList();
        }

        public List<string> toStringList()
        {
            var names = new List<string>();
            if (_characters != null)
            {
                foreach (var character in _characters)
                {
                    names.Add(character.Name);
                }
            }
            return names;
        }

        internal void AddCharacter(Character character)
        {
            if (this._characters == null)
            {
                this._characters = new List<Character>();
            }
            this._characters.Add(character);
        }
    }
}