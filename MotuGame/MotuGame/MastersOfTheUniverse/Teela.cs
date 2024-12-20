using MotuGame.Models.CreatureModel;
using MotuGame.Models.HeroModel;
using MotuGame.SuperAttacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotuGame.MastersOfTheUniverse
{
    public class Teela : HeroModel
    {
        public override string? Name { get; set; } = "Teela";
        public override double Health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override double Stamina { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override double WalkingSpeed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override double SprintSpeed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override bool meleeAttack { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override bool rangedAttack { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override bool isDazed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override bool canBreath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override bool canFly { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override bool isDown { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override bool hasBlood { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override double cooldown { get; set; } = 70;

        public override void Aggression()
        {
            throw new NotImplementedException();
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

        public override void Jump()
        {
            
        }

        public override void LightAttack()
        {
            
        }

        public override void SuperAttack()
        {
         //TalonFighter
         TalonFighter fighter = new TalonFighter();
        }
    }
}
