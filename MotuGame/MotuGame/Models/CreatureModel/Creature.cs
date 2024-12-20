using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotuGame.Models.CreatureModel
{
    //Hauptmodul für alle Kreaturen
    public abstract class Creature
    {

        public abstract string? Name { get; set; }

        public virtual double Health { get; set; } = 100;

        public virtual double Stamina { get; set; } = 100;

        public virtual double WalkingSpeed { get; set; } =20;
        public virtual double SprintSpeed { get; set; } = 60;

        public abstract bool meleeAttack { get; set; }
        public abstract bool rangedAttack { get; set; }

        public virtual bool isDazed { get; set; } = false;
        public virtual bool canBreath { get; set; } = true;

        public virtual bool canFly { get; set; } = false;

        public virtual bool isDown { get; set; } = false;
        public virtual bool hasBlood { get; set; } = true; //LeechAttack on Roboto i.e.

        public abstract void LightAttack();
        public abstract void HeavyAttack();

    }
}
