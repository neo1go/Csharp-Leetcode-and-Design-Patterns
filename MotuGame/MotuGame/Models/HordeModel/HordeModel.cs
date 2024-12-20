using MotuGame.AudioLines;
using MotuGame.Logic.HordeLogic;
using MotuGame.Models.CreatureModel;

namespace MotuGame.Models.HordeModel
{
    public abstract class HordeModel : Creature, IVoiceLines, IAttackSound, IHordeLogic
    {
        public abstract void SuperAttack();
        public abstract void Block();

        public abstract void AudioLine();
        public abstract void AttackSound();

        public abstract double cooldown { get; set; }
        public abstract void Agression();

    }
}
