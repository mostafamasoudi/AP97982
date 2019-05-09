using System;

namespace A8
{
    public class Human
    {
        public string FirstName;
        public string LastName;
        public DateTime BirthDate;
        public int Height;
        public Human(string firstname,string lastname, DateTime birthdate,int height)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.BirthDate = birthdate;
            this.Height = height;
        }
        public static Human operator +(Human first, Human second) 
            => new Human("ChildFirstName", "ChildLastName",DateTime.Today, 30);

        public static bool operator >(Human first, Human second)
            => first.BirthDate < second.BirthDate;

        public static bool operator <(Human first, Human second)
            => first.BirthDate > second.BirthDate;

        public static bool operator >=(Human first, Human second)
            => first.BirthDate <= second.BirthDate;

        public static bool operator <=(Human first, Human second)
           => first.BirthDate >= second.BirthDate;

        public static bool operator ==(Human first, Human second)
           => first.BirthDate == second.BirthDate;

        public static bool operator !=(Human first, Human second)
           => first.BirthDate != second.BirthDate;

        public override bool Equals(object obj)
        {
            bool returnvalue ;
            Human other = (Human)obj;
            if ((other.BirthDate == this.BirthDate)
                && (other.FirstName == this.FirstName)
                && (other.LastName == this.LastName)
                && (other.Height == this.Height))
                returnvalue = true;
            else
                returnvalue = false;

            return returnvalue;
        }
        public override int GetHashCode()
           => this.BirthDate.GetHashCode() ^ this.FirstName.GetHashCode()
              ^ this.LastName.GetHashCode() ^ this.Height.GetHashCode();

        

    }
}