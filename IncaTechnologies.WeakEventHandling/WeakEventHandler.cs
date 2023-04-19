using IncaTechnologies.WeakEventHandling.Abstracts;
using IncaTechnologies.WeakEventHandling.Extensions;
using IncaTechnologies.WeakEventHandling.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace IncaTechnologies.WeakEventHandling
{

    internal sealed class WeakEventHandler<TEventHandler, TOwner, TParam1, TParam2, TParam3> : AbstractWeakEventHandler<TEventHandler, TOwner>, IWeakEventHandler<TParam1, TParam2, TParam3>
        where TEventHandler : Delegate
        where TOwner : class
    {
        private readonly WeakDelegate<TOwner, TParam1, TParam2, TParam3> _weakDelegate;

        public void Invoke(TParam1 param1, TParam2 param2, TParam3 param3)
        {
            if (_weakReference.TryGetTarget(out var owner))
            {
                _weakDelegate.Invoke(owner, param1, param2, param3);
            }
        }

        public WeakEventHandler(TEventHandler eventHandler) : base(eventHandler)
        {
            _weakDelegate = eventHandler.CreateOpenDelegate<TEventHandler, TOwner, TParam1, TParam2, TParam3>();
        }

    }

    internal sealed class WeakEventHandler<TEventHandler, TOwner, TParam1, TParam2> : AbstractWeakEventHandler<TEventHandler, TOwner>, IWeakEventHandler<TParam1, TParam2>
        where TEventHandler : Delegate
        where TOwner : class
    {
        private readonly WeakDelegate<TOwner, TParam1, TParam2> _weakDelegate;

        public void Invoke(TParam1 param1, TParam2 param2)
        {
            if(_weakReference.TryGetTarget(out var owner))
            {
                _weakDelegate.Invoke(owner, param1, param2);
            }          
        }

        public WeakEventHandler(TEventHandler eventHandler) : base(eventHandler)
        {
            _weakDelegate = eventHandler.CreateOpenDelegate<TEventHandler, TOwner, TParam1, TParam2>();
        }
        
    }

    internal sealed class WeakEventHandler<TEventHandler, TOwner, TParam1> : AbstractWeakEventHandler<TEventHandler, TOwner>, IWeakEventHandler<TParam1>
        where TEventHandler : Delegate
        where TOwner : class
    {
        private readonly WeakDelegate<TOwner, TParam1> _weakDelegate;

        public void Invoke(TParam1 param1)
        {
            if (_weakReference.TryGetTarget(out var owner))
            {
                _weakDelegate.Invoke(owner, param1);
            }
        }

        public WeakEventHandler(TEventHandler eventHandler) : base(eventHandler)
        {
            _weakDelegate = eventHandler.CreateOpenDelegate<TEventHandler, TOwner, TParam1>();
        }

    }

    internal sealed class WeakEventHandler<TEventHandler, TOwner> : AbstractWeakEventHandler<TEventHandler, TOwner>, IWeakEventHandler
        where TEventHandler : Delegate
        where TOwner : class
    {
        private readonly WeakDelegate<TOwner> _weakDelegate;

        public void Invoke()
        {
            if (_weakReference.TryGetTarget(out var owner))
            {
                _weakDelegate.Invoke(owner);
            }
        }

        public WeakEventHandler(TEventHandler eventHandler) : base(eventHandler)
        {
            _weakDelegate = eventHandler.CreateOpenDelegate<TEventHandler, TOwner>();
        }

    }
}
