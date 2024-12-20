using MotuGame.Models.VehicleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotuGame.SuperAttacks
{
    public class Roton : Vehicle
    {
        public override string? Name { get; set; } = "Roton";
        public override double Range { get; set; }

        public override void Attack()
        {
           //Schneise 3-4 Heroen breit, etwas weniger Damage
        }
    }
}
