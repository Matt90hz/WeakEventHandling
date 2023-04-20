using IncaTechnologies.WeakEventHandling.Abstracts;
using IncaTechnologies.WeakEventHandling.Interfaces;
using System;

namespace IncaTechnologies.WeakEventHandling
{
    /// <summary>
    /// Implementation of <see cref="IWeakEventHandler{TParam1, TParam2, TParam3}"/> to manage static methods as handlers.
    /// </summary>
    /// <typeparam name="TEventHandler"></typeparam>
    /// <typeparam name="TParam1"></typeparam>
    /// <typeparam name="TParam2"></typeparam>
    /// <typeparam name="TParam3"></typeparam>
    internal sealed class StaticWeakEventHandler<TEventHandler, TParam1, TParam2, TParam3> : AbstractStaticEventHandler<TEventHandler>, IWeakEventHandler<TParam1, TParam2, TParam3> where TEventHandler : Delegate
    {
        /// <summary>
        /// Internal event handler of a known type to be able to control the invokation and aviod the use of DynamicInvoke (too slow).
        /// </summary>
        private readonly Action<TParam1, TParam2, TParam3> _eventHandler;

        /// <inheritdoc/>
        public bool IsAlive => true;

        /// <summary>
        /// Stores the <paramref name="eventHandler"/>.
        /// </summary>
        /// <param name="eventHandler"></param>
        public StaticWeakEventHandler(TEventHandler eventHandler) : base(eventHandler)
        {
            _eventHandler = (Action<TParam1, TParam2, TParam3>)Delegate.CreateDelegate(typeof(Action<TParam1, TParam2, TParam3>), null, eventHandler.Method);
        }

        /// <inheritdoc/>
        public void Invoke(TParam1 param1, TParam2 param2, TParam3 param3)
        {
            _eventHandler.Invoke(param1, param2, param3);
        }

    }

    /// <summary>
    /// Implementation of <see cref="IWeakEventHandler{TParam1, TParam2}"/> to manage static methods as handlers.
    /// </summary>
    /// <typeparam name="TEventHandler"></typeparam>
    /// <typeparam name="TParam1"></typeparam>
    /// <typeparam name="TParam2"></typeparam>
    internal sealed class StaticWeakEventHandler<TEventHandler, TParam1, TParam2> : AbstractStaticEventHandler<TEventHandler>, IWeakEventHandler<TParam1, TParam2> where TEventHandler : Delegate
    {
        /// <summary>
        /// Internal event handler of a known type to be able to control the invokation and aviod the use of DynamicInvoke (too slow).
        /// </summary>
        private readonly Action<TParam1, TParam2> _eventHandler;

        /// <inheritdoc/>
        public bool IsAlive => true;

        /// <summary>
        /// Stores the <paramref name="eventHandler"/>.
        /// </summary>
        /// <param name="eventHandler"></param>
        public StaticWeakEventHandler(TEventHandler eventHandler) : base(eventHandler)
        {
            _eventHandler = (Action<TParam1, TParam2>)Delegate.CreateDelegate(typeof(Action<TParam1, TParam2>), null, eventHandler.Method);
        }

        /// <inheritdoc/>
        public void Invoke(TParam1 param1, TParam2 param2)
        {
            _eventHandler.Invoke(param1, param2);
        }

    }

    /// <summary>
    /// Implementation of <see cref="IWeakEventHandler{TParam1}"/> to manage static methods as handlers.
    /// </summary>
    /// <typeparam name="TEventHandler"></typeparam>
    /// <typeparam name="TParam"></typeparam>
    internal sealed class StaticWeakEventHandler<TEventHandler, TParam> : AbstractStaticEventHandler<TEventHandler>, IWeakEventHandler<TParam> where TEventHandler : Delegate
    {
        /// <summary>
        /// Internal event handler of a known type to be able to control the invokation and aviod the use of DynamicInvoke (too slow).
        /// </summary>
        private readonly Action<TParam> _eventHandler;

        /// <inheritdoc/>
        public bool IsAlive => true;

        /// <summary>
        /// Stores the <paramref name="eventHandler"/>.
        /// </summary>
        /// <param name="eventHandler"></param>
        public StaticWeakEventHandler(TEventHandler eventHandler) : base(eventHandler)
        {
            _eventHandler = (Action<TParam>)Delegate.CreateDelegate(typeof(Action<TParam>), null, eventHandler.Method);
        }

        /// <inheritdoc/>
        public void Invoke(TParam param)
        {
            _eventHandler.Invoke(param);
        }
    }

    /// <summary>
    /// Implementation of <see cref="IWeakEventHandler"/> to manage static methods as handlers.
    /// </summary>
    /// <typeparam name="TEventHandler"></typeparam>
    internal sealed class StaticWeakEventHandler<TEventHandler> : AbstractStaticEventHandler<TEventHandler>, IWeakEventHandler where TEventHandler : Delegate
    {
        /// <summary>
        /// Internal event handler of a known type to be able to control the invokation and aviod the use of DynamicInvoke (too slow).
        /// </summary>
        private readonly Action _eventHandler;

        /// <inheritdoc/>
        public bool IsAlive => true;

        /// <summary>
        /// Stores the <paramref name="eventHandler"/>.
        /// </summary>
        /// <param name="eventHandler"></param>
        public StaticWeakEventHandler(TEventHandler eventHandler) : base(eventHandler)
        {
            _eventHandler = (Action)Delegate.CreateDelegate(typeof(Action), null, eventHandler.Method);
        }

        /// <inheritdoc/>
        public void Invoke()
        {
            _eventHandler.Invoke();
        }
    }
}
