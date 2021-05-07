using System;
using System.Collections.Generic;

namespace DesignPattern.BehaviorPatterns.State
{
    public class PluginWork
    {
        public PluginWork(EventType event2)
        {
            _typeData = event2;
            SetState(_options.States[Convert.ToInt32(_typeData)]);
        }
        public enum EventType
        {
            去打怪 = 0,
            去跑图 = 1,
            去打坐 = 2,
            去摆摊 = 3
        }

        private PluginWorkOptions _options { get; set; } = new PluginWorkOptions();
        private EventType _typeData { get; set; }
        private PluginWorkState _currentState;
        private void SetState(PluginWorkState workState)
        {
            _currentState = workState;
        }
        public void Run()
        {
            _currentState.Run(this);
        }

        public void SwitchState(EventType e)
        {
            this._typeData = e;
            SetState(_options.States[Convert.ToInt32(_typeData)]);
        }
    }
}