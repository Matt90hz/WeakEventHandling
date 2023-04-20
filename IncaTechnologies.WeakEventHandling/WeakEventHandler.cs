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
    /// <summary>
    /// Implementation of <see cref="IWeakEventHandler{TParam1, TParam2, TParam3}"/>.
    /// </summary>
    /// <typeparam name="TEventHandler"></typeparam>
    /// <typeparam name="TOwner"></typeparam>
    /// <typeparam name="TParam1"></typeparam>
    /// <typeparam name="TParam2"></typeparam>
    /// <typeparam name="TParam3"></typeparam>
    internal sealed class WeakEventHandler<TEventHandler, TOwner, TParam1, TParam2, TParam3> : AbstractWeakEventHandler<TEventHandler, TOwner>, IWeakEventHandler<TParam1, TParam2, TParam3>
        where TEventHandler : Delegate
        where TOwner : class
    {
        /// <summary>
        /// Open delegate.
        /// </summary>
        private readonly WeakDelegate<TOwner, TParam1, TParam2, TParam3> _weakDelegate;

        /// <inheritdoc/>
        public void Invoke(TParam1 param1, TParam2 param2, TParam3 param3)
        {
            if (_weakReference.TryGetTarget(out var owner))
            {
                _weakDelegate.Invoke(owner, param1, param2, param3);
            }
        }

        /// <summary>
        /// Creates and store an open delegate form <paramref name="eventHandler"/>
        /// </summary>
        /// <param name="eventHandler"></param>
        public WeakEventHandler(TEventHandler eventHandler) : base(eventHandler)
        {
            _weakDelegate = eventHandler.CreateOpenDelegate<TEventHandler, TOwner, TParam1, TParam2, TParam3>();
        }

    }

    internal sealed class WeakEventHandler<TEventHandler, TOwner, TParam1, TParam2> : AbstractWeakEventHandler<TEventHandler, TOwner>, IWeakEventHandler<TParam1, TParam2>
        where TEventHandler : Delegate
        where TOwner : class
    {
        /// <summary>
        /// Open delegate.
        /// </summary>
        private readonly WeakDelegate<TOwner, TParam1, TParam2> _weakDelegate;

        /// <inheritdoc/>
        public void Invoke(TParam1 param1, TParam2 param2)
        {
            if(_weakReference.TryGetTarget(out var owner))
            {
                _weakDelegate.Invoke(owner, param1, param2);
            }          
        }

        /// <summary>
        /// Creates and store an open delegate form <paramref name="eventHandler"/>
        /// </summary>
        /// <param name="eventHandler"></param>
        public WeakEventHandler(TEventHandler eventHandler) : base(eventHandler)
        {
            _weakDelegate = eventHandler.CreateOpenDelegate<TEventHandler, TOwner, TParam1, TParam2>();
        }
        
    }

    internal sealed class WeakEventHandler<TEventHandler, TOwner, TParam1> : AbstractWeakEventHandler<TEventHandler, TOwner>, IWeakEventHandler<TParam1>
        where TEventHandler : Delegate
        where TOwner : class
    {
        /// <summary>
        /// Open delegate.
        /// </summary>
        private readonly WeakDelegate<TOwner, TParam1> _weakDelegate;

        /// <inheritdoc/>
        public void Invoke(TParam1 param1)
        {
            if (_weakReference.TryGetTarget(out var owner))
            {
                _weakDelegate.Invoke(owner, param1);
            }
        }

        /// <summary>
        /// Creates and store an open delegate form <paramref name="eventHandler"/>
        /// </summary>
        /// <param name="eventHandler"></param>
        public WeakEventHandler(TEventHandler eventHandler) : base(eventHandler)
        {
            _weakDelegate = eventHandler.CreateOpenDelegate<TEventHandler, TOwner, TParam1>();
        }

    }

    internal sealed class WeakEventHandler<TEventHandler, TOwner> : AbstractWeakEventHandler<TEventHandler, TOwner>, IWeakEventHandler
        where TEventHandler : Delegate
        where TOwner : class
    {
        /// <summary>
        /// Open delegate.
        /// </summary>
        private readonly WeakDelegate<TOwner> _weakDelegate;

        /// <inheritdoc/>
        public void Invoke()
        {
            if (_weakReference.TryGetTarget(out var owner))
            {
                _weakDelegate.Invoke(owner);
            }
        }

        /// <summary>
        /// Creates and store an open delegate form <paramref name="eventHandler"/>
        /// </summary>
        /// <param name="eventHandler"></param>
        public WeakEventHandler(TEventHandler eventHandler) : base(eventHandler)
        {
            _weakDelegate = eventHandler.CreateOpenDelegate<TEventHandler, TOwner>();
        }

    }
}
