using System.ComponentModel;

namespace DesignPattern.BehaviorPatterns.Strategy
{
    public class CashContext
    {
        private readonly AbstractCash _cash;

        public enum CashContextType
        {
            [Description("满300返100")]
            MaxReturn,
            [Description("8折")]
            EightFold,
            [Description("正常")]
            Normal
        }

        public CashContext(CashContextType type)
        {
            switch (type)
            {
                case CashContextType.Normal:
                    _cash = new CashNormal();
                    break;
                case CashContextType.EightFold:
                    _cash = new CashRebate(0.8);
                    break;
                case CashContextType.MaxReturn:
                    _cash = new CashReturn(300, 100);
                    break;
            }
        }

        
        /// <summary>
        /// 结算
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        public double AcceptCash(double money)
        {
            return _cash.AcceptCash(money);
        }


    }
}