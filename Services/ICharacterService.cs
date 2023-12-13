using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using relationships.DTOs;
using relationships.Models;

namespace relationshipsRefactor.Services
{
    public interface ICharacterService
    {
        Task<IEnumerable<Character>> GetAllCharacters();
        Task<Character?> GetCharacterById(int id);
        Task<IEnumerable<Character>> CreateCharacter(CharacterCreateDto request);
        Task<bool> DeleteCharacter(Character character);
        Task<bool> Update(CharacterCreateDto character, int id);

    }
}