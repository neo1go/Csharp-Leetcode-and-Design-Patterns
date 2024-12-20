using MotuGame.Models.VehicleModel;

namespace MotuGame.SuperAttacks
{
    public class Mantisaur : Vehicle
    {
        public override string? Name { get; set; }
        public override double Range { get; set; }

        public override void Attack()
        {
            throw new NotImplementedException();
        }
    }
}
