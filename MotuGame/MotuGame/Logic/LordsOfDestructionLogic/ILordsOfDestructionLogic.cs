using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotuGame.Logic.LordsOfDestructionLogic
{
    //Diese Logik dient dazu zu bestimmen, wann und wie häufig mit welcher Anzahl 
    //(auch abhängig vom Schwierigkeitsgrad) die Lords of Destruction angreifen. (Skeletor,Beastman,TrapJaw,Hordak etc.)
    //Außerdem deren Kampfverhalten basierend auf Line of  Sight oder nicht
    public interface ILordsOfDestructionLogic
    {
        // TODO - Es sollen Villains nur sporadisch im Level auftauchen und auch nur einmal jeweils instanziiert werden
        // so das nicht immer die gleichen Gegner auftauchen.
        public abstract void Aggression();
    }
}
