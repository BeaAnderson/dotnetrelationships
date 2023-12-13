using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using relationships.DTOs;
using relationships.Models;

namespace relationshipsRefactor.Services
{
    public interface IFactionService
    {
        Task<IEnumerable<Faction>> GetAllFactions();
        Task<Faction?> GetFactionById(int id);
        Task<IEnumerable<Faction>> CreateFaction(FactionCreateDto request);
        Task<bool> DeleteFaction(Faction faction);
        Task<bool> Update(FactionCreateDto faction, int id);
    }
}