using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using relationships.DTOs;
using relationships.Models;

namespace relationshipsRefactor.Mapper
{
    public interface IWeaponMapper
    {
        Weapon ToEntity(WeaponCreateDto weaponCreateDto);
    }
}