using MotuGame.AudioLines;
using MotuGame.Logic;
using MotuGame.Models.CreatureModel;

namespace MotuGame.Models.MobModel
{
    public abstract class MobModel : Creature, IVoiceLines, IAttackSound, IMobLogic
    {
        //Dies dient der Erstellung der Mobs die andauernd spawnen sollen
        //Sie sind den Mini-Comics entliehen
        public abstract void Aggression();
    }
}
