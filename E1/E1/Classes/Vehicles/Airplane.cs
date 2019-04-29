using E1.Interfaces;

namespace E1.Classes.Vehicles
{
    public class Airplane :IFlyable
    {
        public string Model; 
        public Airplane(double speedRate, string model)
        {
            this.Model = model;
            this.SpeedRate = speedRate;
        }

        public double SpeedRate { get; set ; }

        public string Fly() =>
            $"{Model} with {SpeedRate} speed rate is flying";
    }
}