using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using relationships.Data;
using relationships.DTOs;
using relationships.Models;
using relationshipsRefactor.Mapper;

namespace relationshipsRefactor.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;


        public CharacterService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Character>> CreateCharacter(CharacterCreateDto request)
        {
            var character = _mapper.ToEntity(request);
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            return await _context.Characters.Include(c => c.Backpack).Include(c => c.Weapons).ToListAsync();
        }

        public async Task<bool> DeleteCharacter(Character character)
        {
            _context.Remove(character);
            _context.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<Character>> GetAllCharacters()
        {
            return await _context.Characters
            .Include(c => c.Backpack)
            .Include(c => c.Weapons)
            .Include(c => c.Factions)
            .ToListAsync();
        }

        public async Task<Character?> GetCharacterById(int id)
        {
            var character = await _context.Characters
            .AsNoTracking()
            .Include(c => c.Backpack)
            .Include(c => c.Weapons)
            .Include(c => c.Factions)
            .FirstOrDefaultAsync(c => c.Id == id);

            if (character == null)
            {
                return null;
            }
            return character;
        }

        public async Task<bool> Update(CharacterCreateDto characterdto, int id)
        {
            var dbCharacter = await _context.Characters
            .Include(c => c.Backpack)
            .Include(c => c.Weapons)
            .Include(c => c.Factions)
            .FirstOrDefaultAsync(c => c.Id == id);

            var character = _mapper.ToEntity(characterdto);

            dbCharacter.Name = character.Name;
            dbCharacter.Weapons = character.Weapons;
            dbCharacter.Factions = character.Factions;
            dbCharacter.Backpack = character.Backpack;
            try
            {
                _context.Update(dbCharacter);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}