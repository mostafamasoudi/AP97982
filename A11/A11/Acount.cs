using System;

namespace A11
{
    public class Account
    {
        public double Balance;

        public Account(double balance)
        {
            if(balance>=0)
                this.Balance = balance;
            else
            {
                this.Balance = 0;
                System.Console.WriteLine($"Initial balance is invalid. Setting balance to 0.");
            }
        }

        public virtual void Credit(double amount)
        {
            if(amount>=0)
                this.Balance += amount;
            else
            {
                throw new ArgumentException("Credit amount must be positive");
            }
        }

        public virtual bool Debit(double amount)
        {
            if (this.Balance - amount >= 0)
            {
                this.Balance -= amount;
                return true;
            }
            else
            {
                Console.WriteLine("Debit amount exceeded account balance.");
                return false;
            }
        }

    }
}