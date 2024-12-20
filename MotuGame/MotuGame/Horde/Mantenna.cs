using MotuGame.Models.HordeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotuGame.Horde
{
    public class Mantenna : HordeModel
    {
        public override string? Name { get; set; } = "Mantenna";
        public override bool meleeAttack { get; set; } = false;
        public override bool rangedAttack { get; set; } = true;
        public override double cooldown { get; set; } = 70;

        public override void Agression()
        {
            
        }

        public override void AttackSound()
        {
           
        }

        public override void AudioLine()
        {
            
        }

        public override void Block()
        {
          
        }

        public override void HeavyAttack()
        {
            
        }

        public override void LightAttack()
        {
            
        }

        public override void SuperAttack()
        {
            
        }
    }
}
