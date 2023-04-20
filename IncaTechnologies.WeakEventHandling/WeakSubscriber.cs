using IncaTechnologies.WeakEventHandling.Abstracts;
using IncaTechnologies.WeakEventHandling.Extensions;
using IncaTechnologies.WeakEventHandling.Interfaces;
using System;

namespace IncaTechnologies.WeakEventHandling
{
    /// <summary>
    /// Implementation of <see cref="IWeakSubscriber{TEventHandler}"/>
    /// </summary>
    /// <typeparam name="TEventHandler"></typeparam>
    /// <typeparam name="TOwner"></typeparam>
    /// <typeparam name="TParam1"></typeparam>
    /// <typeparam name="TParam2"></typeparam>
    /// <typeparam name="TParam3"></typeparam>
    internal sealed class WeakSubscriber<TEventHandler, TOwner, TParam1, TParam2, TParam3> : AbstractWeakSubscriber<TEventHandler, TOwner>, IWeakSubscriber<TEventHandler>
        where TEventHandler : Delegate
        where TOwner : class
    {
        private readonly WeakDelegate<TOwner, TParam1, TParam2, TParam3> _weakDelegate;

        /// <summary>
        /// Store a weak delegate created form the <paramref name="callback"/>.
        /// </summary>
        /// <param name="callback"></param>
        public WeakSubscriber(TEventHandler callback) : base(callback)
        {
            _weakDelegate = callback.CreateOpenDelegate<TEventHandler, TOwner, TParam1, TParam2, TParam3>();
        }

        /// <inheritdoc/>
        public TEventHandler WeakHandler => (TEventHandler)Delegate.CreateDelegate(typeof(TEventHandler), this, nameof(WeakSubscriber<TEventHandler, TOwner, TParam1, TParam2, TParam3>.Handler));

        /// <inheritdoc/>
        private void Handler(TParam1 param1, TParam2 param2, TParam3 param3)
        {
            if (_weakReference.TryGetTarget(out var owner))
            {
                _weakDelegate.Invoke(owner, param1, param2, param3);
            }
        }
    }

    /// <summary>
    /// Implementation of <see cref="IWeakSubscriber{TEventHandler}"/>
    /// </summary>
    /// <typeparam name="TEventHandler"></typeparam>
    /// <typeparam name="TOwner"></typeparam>
    /// <typeparam name="TParam1"></typeparam>
    /// <typeparam name="TParam2"></typeparam>
    internal sealed class WeakSubscriber<TEventHandler, TOwner, TParam1, TParam2> : AbstractWeakSubscriber<TEventHandler, TOwner>, IWeakSubscriber<TEventHandler>
        where TEventHandler : Delegate 
        where TOwner : class
    {
        private readonly WeakDelegate<TOwner, TParam1, TParam2> _weakDelegate;

        /// <summary>
        /// Store a weak delegate created form the <paramref name="callback"/>.
        /// </summary>
        /// <param name="callback"></param>
        public WeakSubscriber(TEventHandler callback) : base(callback)
        {
            _weakDelegate = callback.CreateOpenDelegate<TEventHandler, TOwner, TParam1, TParam2>();
        }

        /// <inheritdoc/>
        public TEventHandler WeakHandler => (TEventHandler)Delegate.CreateDelegate(typeof(TEventHandler), this, nameof(WeakSubscriber<TEventHandler, TOwner, TParam1, TParam2>.Handler));

        /// <inheritdoc/>
        private void Handler(TParam1 param1, TParam2 param2)
        {
            if (_weakReference.TryGetTarget(out var owner))
            {
                _weakDelegate.Invoke(owner, param1, param2);
            }
        }
    }

    /// <summary>
    /// Implementation of <see cref="IWeakSubscriber{TEventHandler}"/>
    /// </summary>
    /// <typeparam name="TEventHandler"></typeparam>
    /// <typeparam name="TOwner"></typeparam>
    /// <typeparam name="TParam1"></typeparam>
    internal sealed class WeakSubscriber<TEventHandler, TOwner, TParam1> : AbstractWeakSubscriber<TEventHandler, TOwner>, IWeakSubscriber<TEventHandler>
        where TEventHandler : Delegate
        where TOwner : class
    {
        private readonly WeakDelegate<TOwner, TParam1> _weakDelegate;

        /// <summary>
        /// Store a weak delegate created form the <paramref name="callback"/>.
        /// </summary>
        /// <param name="callback"></param>
        public WeakSubscriber(TEventHandler callback) : base(callback)
        {
            _weakDelegate = callback.CreateOpenDelegate<TEventHandler, TOwner, TParam1>();
        }

        /// <inheritdoc/>
        public TEventHandler WeakHandler => (TEventHandler)Delegate.CreateDelegate(typeof(TEventHandler), this, nameof(WeakSubscriber<TEventHandler, TOwner, TParam1>.Handler));

        /// <inheritdoc/>
        private void Handler(TParam1 param1)
        {
            if (_weakReference.TryGetTarget(out var owner))
            {
                _weakDelegate.Invoke(owner, param1);
            }
        }
    }

    /// <summary>
    /// Implementation of <see cref="IWeakSubscriber{TEventHandler}"/>
    /// </summary>
    /// <typeparam name="TEventHandler"></typeparam>
    /// <typeparam name="TOwner"></typeparam>
    internal sealed class WeakSubscriber<TEventHandler, TOwner> : AbstractWeakSubscriber<TEventHandler, TOwner>, IWeakSubscriber<TEventHandler>
        where TEventHandler : Delegate
        where TOwner : class
    {
        private readonly WeakDelegate<TOwner> _weakDelegate;

        /// <summary>
        /// Store a weak delegate created form the <paramref name="callback"/>.
        /// </summary>
        /// <param name="callback"></param>
        public WeakSubscriber(TEventHandler callback) : base(callback)
        {
            _weakDelegate = callback.CreateOpenDelegate<TEventHandler, TOwner>();
        }

        /// <inheritdoc/>
        public TEventHandler WeakHandler => (TEventHandler)Delegate.CreateDelegate(typeof(TEventHandler), this, nameof(WeakSubscriber<TEventHandler, TOwner>.Handler));

        /// <inheritdoc/>
        private void Handler()
        {
            if (_weakReference.TryGetTarget(out var owner))
            {
                _weakDelegate.Invoke(owner);
            }
        }
    }
}
