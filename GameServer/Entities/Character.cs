using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Entities
{
    class Character
    {
        string charactername = "Ost";
        int health = 10;
        int energy = 10;
        public override string ToString()
        {
            return $"{charactername} {health} {energy}";
        }
    }
}
