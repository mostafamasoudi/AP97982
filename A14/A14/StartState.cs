using System;

namespace A14
{
    /// <summary>
    /// این کلاس بطور کامل پیاده سازی شده است و نیاز به تغییر ندارد.
    /// تنها تغییرات لازم کامنت های شماست 
    /// </summary>
    public class StartState : CalculatorState
    {
        public StartState(Calculator calc) : base(calc) { }

        /// <summary>
        /// اگر در حالت شروع باشیم ،زدن علامت مساوی اینگونه عمل میکند که 
        /// هیچ تاثیری ندارد و برنامه وارد حالت محاسبه میشود 
        /// </summary>
        public override IState EnterEqual() => 
            ProcessOperator(new ComputeState(this.Calc));

        /// <summary>
        /// اگر در حالت شروع ،عدد صفر وارد شود این عدد نمایش و برنامه در همین حالت شروع می ماند
        /// </summary>
        public override IState EnterZeroDigit()
        {
            this.Calc.Display = "0";
            return this;
        }

        /// <summary>
        /// اگر در حالت شروع،عددی غیر از صفر وارد شود عدد مورد نظر نمایش و برنامه وارد 
        /// حالت
        /// AccumulateState
        /// میشود
        /// </summary>
        public override IState EnterNonZeroDigit(char c)
        {
            this.Calc.Display = c.ToString();
            return new AccumulateState(this.Calc);
        }

        /// <summary>
        /// اگر در حالت شروع ،یک عملگر وارد کنیم عدد صفر به عنوان عدد اول ذخیره میشود و 
        ///  عملگر ذخیره و برنامه وارد حالت
        /// ComputeState
        /// میشود 
        /// </summary>
        public override IState EnterOperator(char c) => 
            ProcessOperator(new ComputeState(this.Calc), c);

        /// <summary>
        /// اگر در حالت شروع،علامت اعشار وارد شود مقدار .0 نمایش داده میشود
        /// و برنامه وارد حالت
        /// PointState
        /// میشود
        /// </summary>
        public override IState EnterPoint()
        {
            this.Calc.Display = "0.";
            return new PointState(this.Calc);
        }
    }
}