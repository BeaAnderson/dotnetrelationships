using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using relationships.Models;

namespace relationships.DTOs
{
    public class FactionCreateDto
    {
        public string Name { get; set; }
        public List<string> characters { get; set; }
    }
}