using MotuGame.Logic.HeroTeamLogic;
using MotuGame.Models.HeroModel;
using MotuGame.SuperAttacks;
using System.Runtime.CompilerServices;

namespace MotuGame.MastersOfTheUniverse
{
    public class HeMan : HeroModel
    {
        public override string? Name { get; set; } = "He-Man";
        public override double Health { get; set; } = 100;
        public override double Stamina { get; set; } = 100; 
        public override double WalkingSpeed { get ; set; }
        public override double SprintSpeed { get; set; }
        public override bool meleeAttack { get; set; } = true;
        public override bool rangedAttack { get; set; } = false;
        public override bool isDazed { get; set; }
        public override bool canBreath { get; set; }
        public override bool canFly { get; set; }
        public override bool isDown { get; set; }
        public override bool hasBlood { get; set; }
        public override double cooldown { get; set; } = 70;

        public override void Aggression()
        {
            //Bestimmt, wie sehr der NPC angreift oder dem Spieler hilft und auch autonom seinen Superangriff nutzt
        
            
        }

        public override void AttackSound()
        {
            // TODO - je nach Angriff wechselt der Sound
        }

        public override void AudioLine()
        {
           //TODO - Diese werden je nach Aktivität entschieden 
        }

        public override void Block()
        {
           //Kann blocken da er ein Schild besitzt
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
            //Fahrzeugangriff und bei Sorceress z.B. Heilung (könnte man auch green goddess geben)
            BattleCat cat = new BattleCat();
        }
    }
}
