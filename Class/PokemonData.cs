using ConsumindoApiEmCsharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consumindoApiEmCsharp.Class
{
    public class PokemonData
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public AbilityInfo[] Abilities { get; set; }
    }

}
