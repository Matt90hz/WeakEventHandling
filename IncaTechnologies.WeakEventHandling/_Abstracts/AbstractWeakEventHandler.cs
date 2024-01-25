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
        protected readonly int _closeDelegateHashCode;

        ///<inheritdoc/>
        public bool IsAlive => _weakReference.TryGetTarget(out _);

        /// <summary>
        /// Setup a weak reference to the owner.
        /// </summary>
        /// <param name="eventHandler"></param>
        public AbstractWeakEventHandler(TEventHandler eventHandler)
        {
            _weakReference = new WeakReference<TOwner>((TOwner)eventHandler.Target);
            _closeDelegateHashCode = eventHandler.Method.GetHashCode();
        }

        ///<inheritdoc/>
        public bool Equals(TEventHandler other)
        {
            if (other.Target is null || _weakReference.TryGetTarget(out var target) is false) return false;

            return other.Target.Equals(target) && _closeDelegateHashCode == other.Method.GetHashCode();
        }

        ///<inheritdoc/>
        public override int GetHashCode()
        {
            return _closeDelegateHashCode;
        }

        ///<inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is TEventHandler eventHandler)
            {
                return Equals(eventHandler);
            }

            return ReferenceEquals(this, obj);
        }

    }
}
