using IncaTechnologies.WeakEventHandling.Extensions;
using IncaTechnologies.WeakEventHandling.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IncaTechnologies.WeakEventHandling
{
    /// <inheritdoc cref="IParamsWeakEvent{TEventHandler, TParam1, TParam2, TParam3}"/>
    internal sealed class ParamsWeakEvent<TEventHandler, TParam1, TParam2, TParam3> : IParamsWeakEvent<TEventHandler, TParam1, TParam2, TParam3>
        where TEventHandler : Delegate
    {
        private readonly List<IWeakEventHandler<TParam1, TParam2, TParam3>> _handlers = new List<IWeakEventHandler<TParam1, TParam2, TParam3>>();
        private readonly IWeakEventHandelerFactory<TEventHandler> _weakEventHandelerFactory;

        /// <summary>
        /// Assign the parameters to the fields
        /// </summary>
        /// <param name="weakEventHandelerFactory"></param>
        public ParamsWeakEvent(IWeakEventHandelerFactory<TEventHandler> weakEventHandelerFactory)
        {
            _weakEventHandelerFactory = weakEventHandelerFactory;
        }

        /// <inheritdoc/>
        public void Add(TEventHandler eventHandler)
        {
            _handlers.ClearDead();

            var weakHandler = _weakEventHandelerFactory.CreateWeakEventHandler<TParam1, TParam2, TParam3>(eventHandler);

            _handlers.Add(weakHandler);
        }

        /// <inheritdoc/>
        public void Remove(TEventHandler eventHandler)
        {
            _handlers.ClearDead();

            var toRemove = _handlers.FirstOrDefault(h => h.Equals(eventHandler));

            _handlers.Remove(toRemove);
        }

        /// <inheritdoc/>
        public void Invoke(TParam1 param1, TParam2 param2, TParam3 param3)
        {
            int i = _handlers.Count - 1;

            while (i >= 0)
            {
                if (_handlers[i].IsAlive)
                {
                    _handlers[i].Invoke(param1, param2, param3);
                }
                else
                {
                    _handlers.RemoveAt(i);
                }
                i--;
            }
        }
    }

    /// <inheritdoc cref="IParamsWeakEvent{TEventHandler, TParam1, TParam2}"/>
    internal sealed class ParamsWeakEvent<TEventHandler, TParam1, TParam2> : IParamsWeakEvent<TEventHandler, TParam1, TParam2>
        where TEventHandler : Delegate
    {
        private readonly List<IWeakEventHandler<TParam1, TParam2>> _handlers = new List<IWeakEventHandler<TParam1, TParam2>>();
        private readonly IWeakEventHandelerFactory<TEventHandler> _weakEventHandelerFactory;

        /// <summary>
        /// Assign the parameters to the fields
        /// </summary>
        /// <param name="weakEventHandelerFactory"></param>
        public ParamsWeakEvent(IWeakEventHandelerFactory<TEventHandler> weakEventHandelerFactory)
        {
            _weakEventHandelerFactory = weakEventHandelerFactory;
        }

        /// <inheritdoc/>
        public void Add(TEventHandler eventHandler)
        {
            _handlers.ClearDead();

            var weakHandler = _weakEventHandelerFactory.CreateWeakEventHandler<TParam1, TParam2>(eventHandler);

            _handlers.Add(weakHandler);
        }

        /// <inheritdoc/>
        public void Remove(TEventHandler eventHandler)
        {
            _handlers.ClearDead();

            var toRemove = _handlers.FirstOrDefault(h => h.Equals(eventHandler));

            _handlers.Remove(toRemove);
        }

        /// <inheritdoc/>
        public void Invoke(TParam1 param1, TParam2 param2)
        {
            int i = _handlers.Count - 1;

            while (i >= 0)
            {
                if (_handlers[i].IsAlive)
                {
                    _handlers[i].Invoke(param1, param2);
                }
                else
                {
                    _handlers.RemoveAt(i);
                }
                i--;
            }
        }
    }

    /// <inheritdoc cref="IParamsWeakEvent{TEventHandler, TParam1}"/>
    internal sealed class ParamsWeakEvent<TEventHandler, TParam1> : IParamsWeakEvent<TEventHandler, TParam1>
        where TEventHandler : Delegate
    {
        private readonly List<IWeakEventHandler<TParam1>> _handlers = new List<IWeakEventHandler<TParam1>>();
        private readonly IWeakEventHandelerFactory<TEventHandler> _weakEventHandelerFactory;

        /// <summary>
        /// Assign the parameters to the fields
        /// </summary>
        /// <param name="weakEventHandelerFactory"></param>
        public ParamsWeakEvent(IWeakEventHandelerFactory<TEventHandler> weakEventHandelerFactory)
        {
            _weakEventHandelerFactory = weakEventHandelerFactory;
        }

        /// <inheritdoc/>
        public void Add(TEventHandler eventHandler)
        {
            _handlers.ClearDead();

            var weakHandler = _weakEventHandelerFactory.CreateWeakEventHandler<TParam1>(eventHandler);

            _handlers.Add(weakHandler);
        }

        /// <inheritdoc/>
        public void Remove(TEventHandler eventHandler)
        {
            _handlers.ClearDead();

            var toRemove = _handlers.FirstOrDefault(h => h.Equals(eventHandler));

            _handlers.Remove(toRemove);
        }

        /// <inheritdoc/>
        public void Invoke(TParam1 param1)
        {
            int i = _handlers.Count - 1;

            while (i >= 0)
            {
                if (_handlers[i].IsAlive)
                {
                    _handlers[i].Invoke(param1);
                }
                else
                {
                    _handlers.RemoveAt(i);
                }
                i--;
            }
        }
    }

    /// <inheritdoc cref="IParamsWeakEvent{TEventHandler}"/>
    internal sealed class ParamsWeakEvent<TEventHandler> : IParamsWeakEvent<TEventHandler>
        where TEventHandler : Delegate
    {
        private readonly List<IWeakEventHandler> _handlers = new List<IWeakEventHandler>();
        private readonly IWeakEventHandelerFactory<TEventHandler> _weakEventHandelerFactory;

        /// <summary>
        /// Assign the parameters to the fields
        /// </summary>
        /// <param name="weakEventHandelerFactory"></param>
        public ParamsWeakEvent(IWeakEventHandelerFactory<TEventHandler> weakEventHandelerFactory)
        {
            _weakEventHandelerFactory = weakEventHandelerFactory;
        }

        /// <inheritdoc/>
        public void Add(TEventHandler eventHandler)
        {
            _handlers.ClearDead();

            var weakHandler = _weakEventHandelerFactory.CreateWeakEventHandler(eventHandler);

            _handlers.Add(weakHandler);
        }

        /// <inheritdoc/>
        public void Remove(TEventHandler eventHandler)
        {
            _handlers.ClearDead();

            var toRemove = _handlers.FirstOrDefault(h => h.Equals(eventHandler));

            _handlers.Remove(toRemove);
        }

        /// <inheritdoc/>
        public void Invoke()
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
