namespace DesignPattern.BehaviorPatterns.Strategy
{
    /// <summary>
    /// 折扣价
    /// </summary>
    public class CashRebate : AbstractCash
    {

        private readonly double _rebate;

        public CashRebate(double rebate) => _rebate = rebate;
        
        public override double AcceptCash(double money)
        {
            return money * _rebate;
        }
    }
}