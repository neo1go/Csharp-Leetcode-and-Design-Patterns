using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotuGame.Logic.HeroTeamLogic
{
    //Sobald eine Figur nicht vom Spieler gesteuert wird, soll sie autonom agieren und es soll ein Slider zu den Spieloptionen
    //hinzugefügt werden, der die Aggresivität bestimmt.
    //bei 100% Aggresivität soll immer der naheste Gegner angegriffen werden und es wird keine Rücksicht auf den Spieler genommen.
    //Bei 0% Aggresivität soll der NPC dem Spieler nicht mehr von der Seite weichen und nur immer den Gegner angreifen,
    // der den Spieler angreift.
    // Down but not out Teammates sollten bei Möglichkeit von anderen NPC wieder geheilt werden können.
    public interface IHeroTeamLogic
    {
        public abstract void Aggression();
    }
}
