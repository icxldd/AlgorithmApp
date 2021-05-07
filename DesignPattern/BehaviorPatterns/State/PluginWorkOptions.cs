using System.Collections.Generic;

namespace DesignPattern.BehaviorPatterns.State
{
    public class PluginWorkOptions
    {
        /// <summary>
        /// 状态机集合
        /// </summary>
        public List<PluginWorkState> States { get; set; }

        public PluginWorkOptions()
        {
            States = new List<PluginWorkState>()
            {
                new GosubState(),
                new RunChartState(),
                new MeditateState(),
                new SetUpAStallState()
            };
            
        }
    }
}