using System;
using IncaTechnologies.WeakEventHandling.Interfaces;

namespace IncaTechnologies.WeakEventHandling.Abstracts
{
    /// <summary>
    /// Base class to implement <see cref="IWeakSubscriber{TEventHandler}"/>
    /// </summary>
    /// <typeparam name="TEventHandler">Type of the event handler for the event you want to subscribe to.</typeparam>
    /// <typeparam name="TOwner">The target of the event handler delegate.</typeparam>
    internal abstract class AbstractWeakSubscriber<TEventHandler, TOwner> : IEquatable<TEventHandler>
        where TEventHandler : Delegate
        where TOwner : class
    {
        protected readonly WeakReference<TOwner> _weakReference;
        protected readonly int _hashCodeCloseHandler;

        /// <summary>
        /// Creates a weak reference to the <paramref name="callback"/> target and store the hash code of the <paramref name="callback"/>.
        /// </summary>
        /// <remarks>
        /// I checked the code and the events to unsubscribe use the function <see cref="MulticastDelegate.RemoveImpl(Delegate)"/>.<br/>
        /// Unfortunately the equality check to evaluate if the delegate is the invovation list is made from the value side instead of the invocation list side.
        /// This means that unsubscribe using the call back directily is not possible. You must be use the very handler used to subscribe.
        /// </remarks>
        /// <param name="callback">The delegate ot the mehod that will be invoked when the event triggers.</param>
        public AbstractWeakSubscriber(TEventHandler callback)
        {
            _weakReference = new WeakReference<TOwner>((TOwner)callback.Target);
            _hashCodeCloseHandler = callback.Method.GetHashCode();
        }

        /// <inheritdoc/>
        public bool Equals(TEventHandler other)
        {
            return _weakReference.TryGetTarget(out var owner) && other.Target.Equals(owner) && other.Method.GetHashCode() == _hashCodeCloseHandler;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is TEventHandler eventHandler)
            {
                return Equals(eventHandler);
            }

            return ReferenceEquals(this, obj);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return _hashCodeCloseHandler;
        }
    }
}
