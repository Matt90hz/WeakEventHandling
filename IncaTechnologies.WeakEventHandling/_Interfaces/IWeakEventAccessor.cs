using System;

namespace IncaTechnologies.WeakEventHandling.Interfaces
{
    /// <summary>
    /// Rappresent the subscription and unsubscription functionality of <see cref="IWeakEvent{TEventHandler}"/> or any <see cref="IParamsWeakEvent{TEventHandler}"/>.
    /// </summary>
    /// <typeparam name="TEventHandler"></typeparam>
    public interface IWeakEventAccessor<TEventHandler> where TEventHandler : Delegate
    {
        /// <summary>
        /// Add the <paramref name="eventHandler"/> to the weak event as a <see cref="IWeakEventHandler"/>.
        /// </summary>
        /// <param name="eventHandler">Event handler that has to be subscribed.</param>
        void Add(TEventHandler eventHandler);

        /// <summary>
        /// Removes the matching <see cref="IWeakEventHandler"/> form the weak event.
        /// </summary>
        /// <param name="eventHandler">Event handler that has to be unsubscribed.</param>
        void Remove(TEventHandler eventHandler);
    }
}
