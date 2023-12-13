using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using relationships.DTOs;
using relationships.Models;

namespace relationshipsRefactor.Services
{
    public interface IWeaponService
    {
        Task<IEnumerable<Weapon>> GetAllWeapons();
        Task<Weapon?> GetWeaponById(int id);
        Task<IEnumerable<Weapon>> CreateWeapon(WeaponCreateDto request);
        Task<bool> DeleteWeapon(Weapon weapon);
        Task<bool> Update(WeaponCreateDto weapon, int id);
    }
}