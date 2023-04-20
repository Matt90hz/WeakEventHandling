using System;

namespace IncaTechnologies.WeakEventHandling.Abstracts
{
    /// <summary>
    /// Base class to implement <see cref="StaticWeakEventHandler{TEventHandler}"/>.
    /// </summary>
    /// <typeparam name="TEventHandler"></typeparam>
    internal abstract class AbstractStaticEventHandler<TEventHandler> : IEquatable<TEventHandler> where TEventHandler : Delegate
    {
        protected readonly int _originalDelegateHashCode;

        /// <summary>
        /// Stores the <paramref name="eventHandler"/> hash code.
        /// </summary>
        /// <param name="eventHandler"></param>
        public AbstractStaticEventHandler(TEventHandler eventHandler)
        {
            _originalDelegateHashCode = eventHandler.GetHashCode();
        }    

        /// <inheritdoc/>
        public bool Equals(TEventHandler other)
        {
           return other.GetHashCode() == _originalDelegateHashCode;
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
            return _originalDelegateHashCode;
        }
    }
}
