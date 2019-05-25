using System;
namespace A11
{
    public class CheckingAccount:Account
    {
        public double TransactionFee;

        public CheckingAccount(double balance,double transactionFee)
            :base(balance)
        {
            this.TransactionFee = transactionFee;
        }

        public override void Credit(double amount)
        {
            if(amount>=0)
                this.Balance = this.Balance + amount - this.TransactionFee;
            else
                base.Credit(amount);
        }

        public override bool Debit(double amount)
        {
            if (this.Balance - amount >= 0)
            {
                this.Balance = this.Balance - amount - this.TransactionFee;
                return true;
            }
            else
                return base.Debit(amount);
        }
        
    }
}