using MotuGame.AudioLines;
using MotuGame.Logic.LordsOfDestructionLogic;
using MotuGame.Models.CreatureModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotuGame.Models.LordsOfDestructionChar
{
    //Dient dem Erstellen der Lords of Destruction wie Skeletor oder Beastman etc
    //Diese können bezwungen werden und tauchen dann in dem Level nicht mehr auf sondern flüchten.
    //Sie dienen also nur als Ablenkung oder vielleicht je nach HP Pool als Challenge
    public abstract class LordsOfDestructionModel : Creature, IVoiceLines, IAttackSound,ILordsOfDestructionLogic
    {
        public abstract void SuperAttack();
        public abstract void Block();

        public abstract void AudioLine();
        public abstract void AttackSound();

        public abstract double cooldown { get; set; }
        public abstract void Aggression();
       
    }
}
