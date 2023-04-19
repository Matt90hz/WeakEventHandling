namespace IncaTechnologies.WeakEventHandling.Interfaces
{
    /// <summary>
    /// Rappresent the invoke functionality of <see cref="IWeakEvent{TEventHandler}"/>
    /// </summary>
    public interface IWeakEventInvoke
    {
        /// <summary>
        /// Invokes <see cref="IWeakEvent{TEventHandler}"/>
        /// </summary>
        /// <param name="args">The parameters passed to the event handler. If they do not match the event handler signature exceptions will be thrown.</param>
        void Invoke(params object[] args);
    }
}
