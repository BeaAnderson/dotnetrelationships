using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using relationships.Data;
using relationships.DTOs;
using relationships.Models;
using relationshipsRefactor.Mapper;

namespace relationshipsRefactor.Services
{
    public class FactionService : IFactionService
    {
        private readonly DataContext _context;
        private readonly IFactionMapper _mapper;

        public FactionService(DataContext context, IFactionMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Faction>> CreateFaction(FactionCreateDto request)
        {
            var faction = _mapper.ToEntity(request);
            Console.WriteLine(faction);
            try
            {
                _context.Factions.Add(faction);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(faction);
            }




            return await _context.Factions.Include(f => f.Characters).ToListAsync();
        }

        public async Task<bool> DeleteFaction(Faction faction)
        {
            _context.Remove(faction);
            _context.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<Faction>> GetAllFactions()
        {
            return await _context.Factions.Include(f => f.Characters).ToListAsync();
        }

        public async Task<Faction?> GetFactionById(int id)
        {
            var faction = await _context.Factions.AsNoTracking().Include(f => f.Characters).FirstOrDefaultAsync(f => f.Id == id);
            if (faction == null)
            {
                return null;
            }
            return faction;
        }

        public async Task<bool> Update(FactionCreateDto factionDto, int id)
        {
            var dbFaction = await _context.Factions.Include(f => f.Characters).FirstOrDefaultAsync(f => f.Id == id);

            var faction = _mapper.ToEntity(factionDto);

            dbFaction.Name = faction.Name;
            dbFaction.Characters = faction.Characters;
            try
            {
                _context.Update(dbFaction);
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