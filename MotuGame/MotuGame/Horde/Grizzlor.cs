using MotuGame.Models.HordeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotuGame.Horde
{
    public class Grizzlor : HordeModel
    {
        public override string? Name { get; set; } = "Grizzlor";
        public override bool meleeAttack { get; set; } = true;
        public override bool rangedAttack { get; set; } = true;
        public override double cooldown { get; set; } = 70;

        public override void Agression()
        {
            
        }

        public override void AttackSound()
        {
           //entscheidet basierend auf den bools meleeAttack und rangedAttack
        }

        public override void AudioLine()
        {
            
        }

        public override void Block()
        {
           //kein Block
        }

        public override void HeavyAttack()
        {
            //kann die Armrust sein
        }

        public override void LightAttack()
        {
           //ein Nahkampfschlag
        }

        public override void SuperAttack()
        {
            //vielleicht Rage Mode mit mehr Damage 
        }
    }
}
