using MotuGame.Logic.LordsOfDestructionLogic;
using MotuGame.Models.LordsOfDestructionChar;

namespace MotuGame.LordsOfDestruction
{
    public class Skeletor : LordsOfDestructionModel,ILordsOfDestructionLogic
    {
        public override string? Name { get; set; } = "Skeletor";
        public override double Health { get; set; }
        public override double Stamina { get; set; }
        public override double WalkingSpeed { get; set; }
        public override double SprintSpeed { get; set; }
        public override bool meleeAttack { get; set; } = true;
        public override bool rangedAttack { get; set; } = true;
        public override bool isDazed { get; set; }
        public override bool canBreath { get; set; } = true;
        public override bool canFly { get; set; } = false;
        public override bool isDown { get; set; }
        public override bool hasBlood { get; set; } = true;
        public override double cooldown { get; set; } = 70;

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
