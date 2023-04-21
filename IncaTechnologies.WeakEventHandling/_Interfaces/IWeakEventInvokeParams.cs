namespace IncaTechnologies.WeakEventHandling.Interfaces
{
    /// <summary>
    /// Rappresent the invoke functionality of <see cref="IParamsWeakEvent{TEventHandler, TParam1, TParam2, TParam3}"/>.
    /// </summary>
    /// <typeparam name="TParam1"></typeparam>
    /// <typeparam name="TParam2"></typeparam>
    /// <typeparam name="TParam3"></typeparam>
    public interface IWeakEventInvokeParams<TParam1, TParam2, TParam3>
    {
        /// <summary>
        /// Invokes the <see cref="IParamsWeakEvent{TEventHandler, TParam1, TParam2, TParam3}"/>
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        void Invoke(TParam1 param1, TParam2 param2, TParam3 param3);
    }

    /// <summary>
    /// Rappresent the invoke functionality of <see cref="IWeakEventInvokeParams{TEventHandler, TParam1, TParam2}"/>.
    /// </summary>
    /// <typeparam name="TParam1"></typeparam>
    /// <typeparam name="TParam2"></typeparam>
    public interface IWeakEventInvokeParams<TParam1, TParam2>
    {
        /// <summary>
        /// Invokes the <see cref="IParamsWeakEvent{TEventHandler, TParam1, TParam2}"/>
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        void Invoke(TParam1 param1, TParam2 param2);
    }

    /// <summary>
    /// Rappresent the invoke functionality of <see cref="IWeakEventInvokeParams{TEventHandler, TParam1}"/>.
    /// </summary>
    /// <typeparam name="TParam1"></typeparam>
    public interface IWeakEventInvokeParams<TParam1>
    {
        /// <summary>
        /// Invokes the <see cref="IParamsWeakEvent{TEventHandler, TParam1}"/>.
        /// </summary>
        /// <param name="param1"></param>
        void Invoke(TParam1 param1);
    }

    /// <summary>
    /// Rappresent the invoke functionality of <see cref="IParamsWeakEvent{TEventHandler}"/>.
    /// </summary>
    public interface IWeakEventInvokeParams
    {
        /// <summary>
        /// Invokes the <see cref="IParamsWeakEvent{TEventHandler}"/>.
        /// </summary>
        void Invoke();
    }
}
