using IncaTechnologies.WeakEventHandling.Interfaces;
using System;

namespace IncaTechnologies.WeakEventHandling.Abstracts
{
    /// <summary>
    /// Base class to implement <see cref="IWeakEventHandler"/>.
    /// </summary>
    /// <typeparam name="TEventHandler"></typeparam>
    /// <typeparam name="TOwner"></typeparam>
    internal abstract class AbstractWeakEventHandler<TEventHandler, TOwner> : IWeak, IEquatable<TEventHandler>
        where TEventHandler : Delegate
        where TOwner : class
    {
        protected readonly WeakReference<TOwner> _weakReference;
        protected readonly int _closeDelegateHasCode;

        ///<inheritdoc/>
        public bool IsAlive => _weakReference.TryGetTarget(out _);

        /// <summary>
        /// Setup a weak reference to the owner.
        /// </summary>
        /// <param name="eventHandler"></param>
        public AbstractWeakEventHandler(TEventHandler eventHandler)
        {
            _weakReference = new WeakReference<TOwner>((TOwner)eventHandler.Target);
            _closeDelegateHasCode = eventHandler.GetHashCode();
        }

        ///<inheritdoc/>
        public bool Equals(TEventHandler other)
        {
            return _weakReference.TryGetTarget(out var target) && other.Target.Equals(target);
        }

        ///<inheritdoc/>
        public override int GetHashCode()
        {
            return _closeDelegateHasCode;
        }

        ///<inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is TEventHandler eventHandler)
            {
                if (!_weakReference.TryGetTarget(out var target)) return false;

                return eventHandler.Target.Equals(target) && _closeDelegateHasCode == eventHandler.GetHashCode();
            }

            return ReferenceEquals(this, obj);
        }

    }
}
