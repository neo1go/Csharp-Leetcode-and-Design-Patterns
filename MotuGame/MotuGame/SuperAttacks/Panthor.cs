using MotuGame.Models.VehicleModel;

namespace MotuGame.SuperAttacks
{
    public class Panthor : Vehicle
    {
        public override string? Name { get; set; } = "Panthor";
        public override double Range { get; set; }

        public override void Attack()
        {
            //2-3 Einheiten breit
        }
    }
}
