using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotuGame.Models.VehicleModel
{
    //Diese Fahrzeuge dienen nur als Superangriff und haben unterschiedliche Angriffsmuster
    //Wind Raider, AttackTrak, DragonWalker, RoadRipper, Talon Fighter, Stridor, BattleCat, Bashasaurus
    //Roton, Night Stalker, Fright Fighter, Sypdor,  

    
    public abstract class Vehicle
    {
        public abstract string? Name { get; set; }

        public abstract double Range {  get; set; } //entscheidet, wieviele Gegner damaged werden

        public abstract void Attack();

    }
}
