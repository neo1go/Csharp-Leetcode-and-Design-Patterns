using MotuGame.Models.VehicleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotuGame.SuperAttacks
{
    internal class TalonFighter : Vehicle
    {
        public override string? Name { get; set; } = "Talon Fighter";
        public override double Range { get ; set ; }

        public override void Attack()
        {
            
        }
    }
}
