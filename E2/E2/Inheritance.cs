using System;

namespace E2
{
    public abstract class Person
    {
        private string _Name;
        public virtual string Name
        {
            get => _Name;

            set
            {
                if (IsFemale)
                {
                    _Name = $"خانم {value}";
                }
                else
                {
                    if(this is Teacher)
                        _Name = $"استاد {value}";
                    else
                        _Name = $"آقای {value}";
                }
            }
        }
        public bool IsFemale;
        public abstract int LunchRate { get; }

        public Person(string name, bool isfemale)
        {

            this.IsFemale = isfemale;
            this.Name = name;
        }
    }

    public class Student : Person
    {
        public Student(string name, bool isfemale)
            : base(name, isfemale)
        { }
        public override int LunchRate => 2000;
        
    }


    public class Employee : Person
    {
        public Employee(string name, bool isfemale) 
            : base(name, isfemale)
        {
        }

        public override int LunchRate => 5000;

        public virtual int CalculateSalary(int v)
            => 5000 * v;
    }

    public class Teacher : Employee
    {
        public Teacher(string name, bool isfemale)
            : base(name, isfemale)
        { }
        
        public override int LunchRate => 10000;

        public override int CalculateSalary(int v)
            => 20000 * v;
    }
}