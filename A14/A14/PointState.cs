namespace A14
{
    /// <summary>
    /// این وضعیت نشان دهنده حالتی است که نقطه زده شده
    /// این وضعیت شبیه وضعیت
    /// Accumulate
    /// است
    /// تنها فرقش این است که نقطه جدیدی نمی شود زد.
    /// تغییرات لازم را برای این کار بدهید.
    /// </summary>
    public class PointState : AccumulateState
    {
        public PointState(Calculator calc) : base(calc) { }

        //#1 لطفا!
        public override IState EnterZeroDigit()
        {
            this.Calc.Display += '0';
            return new PointState(this.Calc);
        }

        public override IState EnterNonZeroDigit(char c)
        {
            this.Calc.Display += c;
            return new PointState(this.Calc);
        }

        public override IState EnterPoint()
        {
            return new PointState(this.Calc);
        }
    }
}