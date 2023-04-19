using System;

namespace IncaTechnologies.WeakEventHandling.Interfaces
{
    /// <summary>
    /// Expose an handler that that stores the original target in a <see cref="WeakReference"/>. In this way the target can be garbage collected.
    /// </summary>
    /// <remarks>
    /// Pay attention, the original target get garbage collected but an instance of this "wrapper" will live untill the <see cref="IWeakSubscriber{TEventHandler}.WeakHandler"/> is unsubscribed and any referece to it removed.<br/>
    /// For this reason make sense use this only if the original target is an heavy object in terms of memory consumption and there is no way of unsubscribe to the event or edit the event to be a <see cref="IWeakEvent{TEventHandler}"/>.
    /// </remarks>
    /// <typeparam name="TEventHandler">The type of the event handler of the event you want to subscribe to.</typeparam>
    public interface IWeakSubscriber<TEventHandler> where TEventHandler : Delegate
    {
        /// <summary>
        /// An handler tha can be used to subscribe to event that preserve only a <see cref="WeakReference"/> to the original <see cref="Delegate.Target"/>.
        /// </summary>
        TEventHandler WeakHandler { get; }
    }
}
