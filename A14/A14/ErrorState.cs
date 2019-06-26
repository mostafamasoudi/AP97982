namespace A14
{
    /// <summary>
    /// ماشین حساب وقتی به این حالت وارد میشود که خطایی رخ داده باشد
    /// از این حالت هر کلیدی که فشار داده شود به وضعیت اولیه باید برگردیم
    /// #2 لطفا!
    /// </summary>
    public class ErrorState : CalculatorState
    {
        public ErrorState(Calculator calc) : base(calc) { }
        public override IState EnterEqual() => Reset();
        public override IState EnterNonZeroDigit(char c) => Reset();
        public override IState EnterZeroDigit() => Reset();
        public override IState EnterOperator(char c) => Reset();
        public override IState EnterPoint() => Reset();
        
        public IState Reset()
        {
            this.Calc.Clear();
            return new StartState(this.Calc);
        }

    }
}