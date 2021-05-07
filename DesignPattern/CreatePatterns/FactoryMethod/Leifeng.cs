using System;

namespace DesignPattern.CreatePatterns.FactoryMethod
{
    public abstract class Leifeng
    {
        public virtual void Sweep()
        {
            Console.WriteLine("扫地");
        }

        public virtual void Wash()
        {
            Console.WriteLine("洗衣");
        }

        public virtual void BuyRice()
        {
            Console.WriteLine("买米");
        }
    }
}