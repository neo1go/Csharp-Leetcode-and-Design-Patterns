using MotuGame.Logic.HeroTeamLogic;
using MotuGame.Models.HeroModel;
using MotuGame.SuperAttacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotuGame.MastersOfTheUniverse
{
    public class ManAtArms :HeroModel, IHeroTeamLogic
    {
        public override double cooldown { get; set; } = 80;
        public override string? Name { get; set; } = "Man at Arms";
        public override bool meleeAttack { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override bool rangedAttack { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

       

        public override void Aggression()
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
            //grafisches Aufleuchten ,deflektiert sowohl Schüsse als auch Schläge
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
            //Wind Raider
            WindRaider raider = new WindRaider();
        }
    }
}
