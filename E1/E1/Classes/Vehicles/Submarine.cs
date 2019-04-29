using E1.Interfaces;

namespace E1.Classes.Vehicles
{
    public class Submarine :ISwimable
    {
        public string Model;
        public double MaxDepthSupported;
        public double SpeedRate { get; set; }

        public Submarine(string model, double maxDepthSupported, double speedRate)
        {
            this.Model = model;
            this.MaxDepthSupported = maxDepthSupported;
            this.SpeedRate = speedRate;
        }

        public string Swim() =>
            $"{Model} is a {nameof(Submarine)} and is swimming in {MaxDepthSupported} meter depth";
    }
}