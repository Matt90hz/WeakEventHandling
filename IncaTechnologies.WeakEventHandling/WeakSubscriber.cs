using IncaTechnologies.WeakEventHandling.Abstracts;
using IncaTechnologies.WeakEventHandling.Extensions;
using IncaTechnologies.WeakEventHandling.Interfaces;
using System;

namespace IncaTechnologies.WeakEventHandling
{

    internal sealed class WeakSubscriber<TEventHandler, TOwner, TParam1, TParam2, TParam3> : AbstractWeakSubscriber<TEventHandler, TOwner>, IWeakSubscriber<TEventHandler>
        where TEventHandler : Delegate
        where TOwner : class
    {
        private readonly WeakDelegate<TOwner, TParam1, TParam2, TParam3> _weakDelegate;

        public WeakSubscriber(TEventHandler callback) : base(callback)
        {
            _weakDelegate = callback.CreateOpenDelegate<TEventHandler, TOwner, TParam1, TParam2, TParam3>();
        }

        public TEventHandler WeakHandler => (TEventHandler)Delegate.CreateDelegate(typeof(TEventHandler), this, nameof(WeakSubscriber<TEventHandler, TOwner, TParam1, TParam2, TParam3>.Handler));

        private void Handler(TParam1 param1, TParam2 param2, TParam3 param3)
        {
            if (_weakReference.TryGetTarget(out var owner))
            {
                _weakDelegate.Invoke(owner, param1, param2, param3);
            }
        }
    }

    internal sealed class WeakSubscriber<TEventHandler, TOwner, TParam1, TParam2> : AbstractWeakSubscriber<TEventHandler, TOwner>, IWeakSubscriber<TEventHandler>
        where TEventHandler : Delegate 
        where TOwner : class
    {
        private readonly WeakDelegate<TOwner, TParam1, TParam2> _weakDelegate;

        public WeakSubscriber(TEventHandler callback) : base(callback)
        {
            _weakDelegate = callback.CreateOpenDelegate<TEventHandler, TOwner, TParam1, TParam2>();
        }

        public TEventHandler WeakHandler => (TEventHandler)Delegate.CreateDelegate(typeof(TEventHandler), this, nameof(WeakSubscriber<TEventHandler, TOwner, TParam1, TParam2>.Handler));

        private void Handler(TParam1 param1, TParam2 param2)
        {
            if (_weakReference.TryGetTarget(out var owner))
            {
                _weakDelegate.Invoke(owner, param1, param2);
            }
        }
    }

    internal sealed class WeakSubscriber<TEventHandler, TOwner, TParam1> : AbstractWeakSubscriber<TEventHandler, TOwner>, IWeakSubscriber<TEventHandler>
        where TEventHandler : Delegate
        where TOwner : class
    {
        private readonly WeakDelegate<TOwner, TParam1> _weakDelegate;

        public WeakSubscriber(TEventHandler callback) : base(callback)
        {
            _weakDelegate = callback.CreateOpenDelegate<TEventHandler, TOwner, TParam1>();
        }

        public TEventHandler WeakHandler => (TEventHandler)Delegate.CreateDelegate(typeof(TEventHandler), this, nameof(WeakSubscriber<TEventHandler, TOwner, TParam1>.Handler));

        private void Handler(TParam1 param1)
        {
            if (_weakReference.TryGetTarget(out var owner))
            {
                _weakDelegate.Invoke(owner, param1);
            }
        }
    }

    internal sealed class WeakSubscriber<TEventHandler, TOwner> : AbstractWeakSubscriber<TEventHandler, TOwner>, IWeakSubscriber<TEventHandler>
        where TEventHandler : Delegate
        where TOwner : class
    {
        private readonly WeakDelegate<TOwner> _weakDelegate;


        public WeakSubscriber(TEventHandler callback) : base(callback)
        {
            _weakDelegate = callback.CreateOpenDelegate<TEventHandler, TOwner>();
        }

        public TEventHandler WeakHandler => (TEventHandler)Delegate.CreateDelegate(typeof(TEventHandler), this, nameof(WeakSubscriber<TEventHandler, TOwner>.Handler));

        private void Handler()
        {
            if (_weakReference.TryGetTarget(out var owner))
            {
                _weakDelegate.Invoke(owner);
            }
        }
    }
}
