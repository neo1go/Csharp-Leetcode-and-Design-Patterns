using MotuGame.AudioLines;
using MotuGame.Logic.HeroTeamLogic;
using MotuGame.Models.CreatureModel;

namespace MotuGame.Models.HeroModel
{
    public abstract class HeroModel : Creature, IVoiceLines, IAttackSound, IHeroTeamLogic
    {
        //Super Attack wie z.B. Energiewelle, oder sehr starker Schuss bei manchen Helden wie z.B. Man at Arms
        //es könnten auch Heilung oder Beeinflussung der Angriffslust sein.
        public abstract void SuperAttack();

        public abstract void Jump();

        public abstract void Block();

        public abstract void AudioLine();
        public abstract void AttackSound();

        public abstract double cooldown { get; set; }

        public abstract void Aggression();
        
            
        
    }
}
