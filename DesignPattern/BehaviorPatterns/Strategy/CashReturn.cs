using System;

namespace DesignPattern.BehaviorPatterns.Strategy
{
    /// <summary>
    /// 满多少减多少
    /// </summary>
    public class CashReturn : AbstractCash
    {
        private readonly double _condition;
        private readonly double _return;

        public CashReturn(double condition, double @return)
        {
            _condition = condition;
            _return = @return;
        }

        public override double AcceptCash(double money)
        {
            return money >= _condition ? money - Math.Floor(money / _condition) * _return : money;
        }
    }
}