using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using relationships.Data;
using relationships.DTOs;
using relationships.Models;
using relationshipsRefactor.Mapper;

namespace relationshipsRefactor.Services
{
    public class WeaponService : IWeaponService
    {
        private readonly DataContext _context;
        private readonly IWeaponMapper _mapper;

        public WeaponService(DataContext context, IWeaponMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Weapon>> CreateWeapon(WeaponCreateDto request)
        {
            var weapon = _mapper.ToEntity(request);
            _context.Weapons.Add(weapon);
            await _context.SaveChangesAsync();

            return await _context.Weapons.Include(w => w.Character).ToListAsync();
        }

        public async Task<bool> DeleteWeapon(Weapon weapon)
        {
            _context.Remove(weapon);
            _context.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<Weapon>> GetAllWeapons()
        {
            return await _context.Weapons.Include(w => w.Character).ToListAsync();
        }

        public async Task<Weapon?> GetWeaponById(int id)
        {
            var weapon = await _context.Weapons
            .AsNoTracking().Include(w => w.Character).FirstOrDefaultAsync(w => w.Id == id);

            if (weapon == null)
            {
                return null;
            }
            return weapon;
        }

        public async Task<bool> Update(WeaponCreateDto weaponDto, int id)
        {
            var dbweapon = await _context.Weapons
            .Include(w => w.Character).FirstOrDefaultAsync(w => w.Id == id);

            var weapon = _mapper.ToEntity(weaponDto);

            dbweapon.Name = weapon.Name;
            dbweapon.Character = weapon.Character;
            try
            {
                _context.Update(dbweapon);
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