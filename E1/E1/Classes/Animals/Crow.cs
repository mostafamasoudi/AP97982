using System;
using E1.Enums;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes.Animals
{
    public class Crow :IFlyable , IAnimal
    {
        public Crow(string name, int age, double health, double speedRate)
        {
            this.Name = name;
            this.Age = age;
            this.Health = health;
            this.SpeedRate = speedRate;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public double Health { get; set; }
        public double SpeedRate { get; set; }

        public string EatFood()=>
             $"{this.Name} is a {nameof(Crow)} and is eating";

        public string Fly()=>
             $"{this.Name} is a {nameof(Crow)} and is flying";

        public string Move(Environment environment)
        {
            if (environment == Environment.Air)
                return Fly();
            else
                return $"{this.Name} is a {nameof(Crow)} and can't move in {environment} environment";
        }

        public string Reproduction(IAnimal animal)=>
             $"{this.Name} is a {nameof(Crow)} and reproductive with {animal.Name}";
    }
}