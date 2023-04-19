using IncaTechnologies.WeakEventHandling.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IncaTechnologies.WeakEventHandling
{
    internal sealed class WeakEvent<TEventHandler, TParam1, TParam2, TParam3> : IWeakEvent<TEventHandler>
        where TEventHandler : Delegate
    {
        private readonly List<IWeakEventHandler<TParam1, TParam2, TParam3>> _handlers = new List<IWeakEventHandler<TParam1, TParam2, TParam3>>();
        private readonly IWeakEventHandelerFactory<TEventHandler> _weakEventHandelerFactory;

        public WeakEvent(IWeakEventHandelerFactory<TEventHandler> weakEventHandelerFactory)
        {
            _weakEventHandelerFactory = weakEventHandelerFactory;
        }

        public void Add(TEventHandler eventHandler)
        {
            var weakHandler = _weakEventHandelerFactory.CreateWeakEventHandler<TParam1, TParam2, TParam3>(eventHandler);

            _handlers.Add(weakHandler);
        }

        public void Remove(TEventHandler eventHandler)
        {
            var toRemove = _handlers.FirstOrDefault(h => h.Equals(eventHandler));

            _handlers.Remove(toRemove);
        }

        public void Invoke(params object[] args)
        {
            int i = _handlers.Count - 1;

            while (i >= 0)
            {
                if (_handlers[i].IsAlive)
                {
                    _handlers[i].Invoke((TParam1)args[0], (TParam2)args[1], (TParam3)args[2]);
                }
                else
                {
                    _handlers.RemoveAt(i);
                }
                i--;
            }
        }
    }

    internal sealed class WeakEvent<TEventHandler, TParam1, TParam2> : IWeakEvent<TEventHandler>
        where TEventHandler : Delegate
    {
        private readonly List<IWeakEventHandler<TParam1, TParam2>> _handlers = new List<IWeakEventHandler<TParam1, TParam2>>();
        private readonly IWeakEventHandelerFactory<TEventHandler> _weakEventHandelerFactory;

        public WeakEvent(IWeakEventHandelerFactory<TEventHandler> weakEventHandelerFactory)
        {
            _weakEventHandelerFactory = weakEventHandelerFactory;
        }

        public void Add(TEventHandler eventHandler)
        {
            var weakHandler = _weakEventHandelerFactory.CreateWeakEventHandler<TParam1, TParam2>(eventHandler);

            _handlers.Add(weakHandler);
        }

        public void Remove(TEventHandler eventHandler)
        {
            var toRemove = _handlers.FirstOrDefault(h => h.Equals(eventHandler));

            _handlers.Remove(toRemove);
        }

        public void Invoke(params object[] args)
        {
            int i = _handlers.Count - 1;

            while (i >= 0)
            {
                if (_handlers[i].IsAlive)
                {
                    _handlers[i].Invoke((TParam1)args[0], (TParam2)args[1]);
                }
                else
                {
                    _handlers.RemoveAt(i);
                }
                i--;
            }
        }
    }

    internal sealed class WeakEvent<TEventHandler, TParam> : IWeakEvent<TEventHandler>
        where TEventHandler : Delegate
    {
        private readonly List<IWeakEventHandler<TParam>> _handlers = new List<IWeakEventHandler<TParam>>();
        private readonly IWeakEventHandelerFactory<TEventHandler> _weakEventHandelerFactory;

        public WeakEvent(IWeakEventHandelerFactory<TEventHandler> weakEventHandelerFactory)
        {
            _weakEventHandelerFactory = weakEventHandelerFactory;
        }

        public void Add(TEventHandler eventHandler)
        {
            var weakHandler = _weakEventHandelerFactory.CreateWeakEventHandler<TParam>(eventHandler);

            _handlers.Add(weakHandler);
        }

        public void Remove(TEventHandler eventHandler)
        {
            var toRemove = _handlers.FirstOrDefault(h => h.Equals(eventHandler));

            _handlers.Remove(toRemove);
        }

        public void Invoke(params object[] args)
        {
            int i = _handlers.Count - 1;

            while (i >= 0)
            {
                if (_handlers[i].IsAlive)
                {
                    _handlers[i].Invoke((TParam)args[0]);
                }
                else
                {
                    _handlers.RemoveAt(i);
                }
                i--;
            }
        }
    }

    internal sealed class WeakEvent<TEventHandler> : IWeakEvent<TEventHandler>
        where TEventHandler : Delegate
    {
        private readonly List<IWeakEventHandler> _handlers = new List<IWeakEventHandler>();
        private readonly IWeakEventHandelerFactory<TEventHandler> _weakEventHandelerFactory;

        public WeakEvent(IWeakEventHandelerFactory<TEventHandler> weakEventHandelerFactory)
        {
            _weakEventHandelerFactory = weakEventHandelerFactory;
        }

        public void Add(TEventHandler eventHandler)
        {
            var weakHandler = _weakEventHandelerFactory.CreateWeakEventHandler(eventHandler);

            _handlers.Add(weakHandler);
        }

        public void Remove(TEventHandler eventHandler)
        {
            var toRemove = _handlers.FirstOrDefault(h => h.Equals(eventHandler));

            _handlers.Remove(toRemove);
        }

        public void Invoke(params object[] args)
        {
            int i = _handlers.Count - 1;

            while (i >= 0)
            {
                if (_handlers[i].IsAlive)
                {
                    _handlers[i].Invoke();
                }
                else
                {
                    _handlers.RemoveAt(i);
                }
                i--;
            }
        }
    }
}
