﻿using System;
using E1.Enums;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes.Animals
{
    public class Frog :IAnimal,IWalkable,ISwimable
    {
        public Frog(string name, int age, double health, double speedRate)
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
             $"{this.Name} is a {nameof(Frog)} and is eating";

        public string Move(Environment environment)
        {
            if (environment == Environment.Land)
                return Walk();
            else if (environment == Environment.Watery)
                return Swim();
            else
                return $"{this.Name} is a {nameof(Frog)} and can't move in {environment} environment";
        }

        public string Reproduction(IAnimal animal)=>
            $"{this.Name} is a {nameof(Frog)} and reproductive with {animal.Name}";

        public string Swim() =>
             $"{this.Name} is a {nameof(Frog)} and is swimming";

        public string Walk()=>
            $"{this.Name} is a {nameof(Frog)} and is walking";

    }
}