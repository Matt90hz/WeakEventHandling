using IncaTechnologies.WeakEventHandling.Abstracts;
using IncaTechnologies.WeakEventHandling.Interfaces;
using System;

namespace IncaTechnologies.WeakEventHandling
{
    internal sealed class StaticWeakEventHandler<TEventHandler, TParam1, TParam2, TParam3> : AbstractStaticEventHandler<TEventHandler>, IWeakEventHandler<TParam1, TParam2, TParam3> where TEventHandler : Delegate
    {
        private readonly Action<TParam1, TParam2, TParam3> _eventHandler;

        public bool IsAlive => true;

        public StaticWeakEventHandler(TEventHandler eventHandler) : base(eventHandler)
        {
            _eventHandler = (Action<TParam1, TParam2, TParam3>)Delegate.CreateDelegate(typeof(Action<TParam1, TParam2, TParam3>), null, eventHandler.Method);
        }

        public void Invoke(TParam1 param1, TParam2 param2, TParam3 param3)
        {
            _eventHandler.Invoke(param1, param2, param3);
        }

    }

    internal sealed class StaticWeakEventHandler<TEventHandler, TParam1, TParam2> : AbstractStaticEventHandler<TEventHandler>, IWeakEventHandler<TParam1, TParam2> where TEventHandler : Delegate
    {
        private readonly Action<TParam1, TParam2> _eventHandler;

        public bool IsAlive => true;

        public StaticWeakEventHandler(TEventHandler eventHandler) : base(eventHandler)
        {
            _eventHandler = (Action<TParam1, TParam2>)Delegate.CreateDelegate(typeof(Action<TParam1, TParam2>), null, eventHandler.Method);
        }

        public void Invoke(TParam1 param1, TParam2 param2)
        {
            _eventHandler.Invoke(param1, param2);
        }

    }

    internal sealed class StaticWeakEventHandler<TEventHandler, TParam> : AbstractStaticEventHandler<TEventHandler>, IWeakEventHandler<TParam> where TEventHandler : Delegate
    {
        private readonly Action<TParam> _eventHandler;

        public bool IsAlive => true;

        public StaticWeakEventHandler(TEventHandler eventHandler) : base(eventHandler)
        {
            _eventHandler = (Action<TParam>)Delegate.CreateDelegate(typeof(Action<TParam>), null, eventHandler.Method);
        }

        public void Invoke(TParam param)
        {
            _eventHandler.Invoke(param);
        }
    }

    internal sealed class StaticWeakEventHandler<TEventHandler> : AbstractStaticEventHandler<TEventHandler>, IWeakEventHandler where TEventHandler : Delegate
    {
        private readonly Action _eventHandler;

        public bool IsAlive => true;

        public StaticWeakEventHandler(TEventHandler eventHandler) : base(eventHandler)
        {
            _eventHandler = (Action)Delegate.CreateDelegate(typeof(Action), null, eventHandler.Method);
        }

        public void Invoke()
        {
            _eventHandler.Invoke();
        }
    }
}
