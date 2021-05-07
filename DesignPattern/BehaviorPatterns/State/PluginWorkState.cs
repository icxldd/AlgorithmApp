using System;

namespace DesignPattern.BehaviorPatterns.State
{
    /// <summary>
    /// 外挂state
    /// </summary>
    public abstract class PluginWorkState
    {
        public abstract void Run(PluginWork work);
    }

    public class GosubState : PluginWorkState
    {
        public override void Run(PluginWork work)
        {
            Console.WriteLine("开始打怪");
        }
    }

    
    public class RunChartState : PluginWorkState
    {
        public override void Run(PluginWork work)
        {
            Console.WriteLine("开始跑图");
        }
    }
    
    public class MeditateState : PluginWorkState
    {
        public override void Run(PluginWork work)
        {
            Console.WriteLine("开始打坐");
        }
    }
    
    public class SetUpAStallState : PluginWorkState
    {
        public override void Run(PluginWork work)
        {
            Console.WriteLine("开始摆摊");
        }
    }


}