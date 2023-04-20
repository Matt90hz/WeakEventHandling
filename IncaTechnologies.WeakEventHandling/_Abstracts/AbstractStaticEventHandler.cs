using System;

namespace IncaTechnologies.WeakEventHandling.Abstracts
{
    internal abstract class AbstractStaticEventHandler<TEventHandler> : IEquatable<TEventHandler> where TEventHandler : Delegate
    {
        protected readonly int _originalDelegateHashCode;

        public AbstractStaticEventHandler(TEventHandler eventHandler)
        {
            _originalDelegateHashCode = eventHandler.GetHashCode();
        }    

        public bool Equals(TEventHandler other)
        {
           return other.GetHashCode() == _originalDelegateHashCode;
        }

        public override bool Equals(object obj)
        {
            if (obj is TEventHandler eventHandler)
            {
                return Equals(eventHandler);
            }

            return ReferenceEquals(this, obj);
        }

        public override int GetHashCode()
        {
            return _originalDelegateHashCode;
        }
    }
}
