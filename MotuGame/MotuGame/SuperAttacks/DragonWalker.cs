using MotuGame.Models.VehicleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotuGame.SuperAttacks
{
    public class DragonWalker : Vehicle
    {
        public override string? Name { get; set; } = "Dragon Walker";
        public override double Range { get;set; }

        public override void Attack()
        {
            
        }
    }
}
