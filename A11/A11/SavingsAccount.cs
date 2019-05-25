namespace A11
{
    public class SavingsAccount:Account
    {
        public double InterestRate;

        public SavingsAccount(double balance,double interestRate)
            :base(balance)
        {
            this.InterestRate = interestRate;
        }

        public double CalculateInterest()
        {
            return this.Balance * this.InterestRate;
        }
    }
}