using MotuGame.Models.VehicleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotuGame.SuperAttacks
{
    internal class AttackTrak : Vehicle
    {
        public override string? Name { get; set; } = "Attack Trak";
        public override double Range { get; set; }

        public override void Attack()
        {
          //Schneise 2 bis 3 Heros breit
        }
    }
}
