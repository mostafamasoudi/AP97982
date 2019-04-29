using System;
using System.Collections.Generic;
using System.Linq;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes
{
    public class GameBoard<_Type> where  _Type : IAnimal
    {
        public GameBoard(IEnumerable<IAnimal> animals)
        {
            Animals = animals.ToList();
        }

        public List<IAnimal> Animals { get; set; }

        public string[] MoveAnimals()
        {
            List<string> moveAnimals = new List<string>();
            foreach (var animals in Animals)
            {
                moveAnimals.Add(animals.Move(Environment.Air));
                moveAnimals.Add(animals.Move(Environment.Land));
                moveAnimals.Add(animals.Move(Environment.Watery));
            }
            return moveAnimals.ToArray();
        }
    }
}