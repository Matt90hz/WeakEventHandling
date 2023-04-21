using System;
using System.Diagnostics.CodeAnalysis;

namespace IncaTechnologies.WeakEventHandling.Interfaces
{
#pragma warning disable CA1711
    /// <summary>
    /// <see cref="IWeakEvent{TEventHandler}"/> and <see cref="IParamsWeakEvent{TEventHandler, TParam1, TParam2, TParam3}"/> store this instead of the original handler.
    /// This handler retain only a <see cref="WeakReference"/> to the target of the original handler.
    /// </summary>
    /// <typeparam name="TParam1"></typeparam>
    /// <typeparam name="TParam2"></typeparam>
    /// <typeparam name="TParam3"></typeparam>
    public interface IWeakEventHandler<TParam1, TParam2, TParam3> : IWeak
    {
        /// <summary>
        /// Invokes the handler on the original target.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        void Invoke(TParam1 param1, TParam2 param2, TParam3 param3);
    }

    /// <summary>
    /// <see cref="IWeakEvent{TEventHandler}"/> and <see cref="IParamsWeakEvent{TEventHandler, TParam1, TParam2}"/> store this instead of the original handler.
    /// This handler retain only a <see cref="WeakReference"/> to the target of the original handler.
    /// </summary>
    /// <typeparam name="TParam1"></typeparam>
    /// <typeparam name="TParam2"></typeparam>
    public interface IWeakEventHandler<TParam1, TParam2> : IWeak
    {
        /// <summary>
        /// Invokes the handler on the original target.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        void Invoke(TParam1 param1, TParam2 param2);
    }

    /// <summary>
    /// <see cref="IWeakEvent{TEventHandler}"/> and <see cref="IParamsWeakEvent{TEventHandler, TParam1}"/> store this instead of the original handler.
    /// This handler retain only a <see cref="WeakReference"/> to the target of the original handler.
    /// </summary>
    /// <typeparam name="TParam"></typeparam>
    public interface IWeakEventHandler<TParam> : IWeak
    {
        /// <summary>
        /// Invokes the handler on the original target.
        /// </summary>
        /// <param name="param"></param>
        void Invoke(TParam param);
    }

    /// <summary>
    /// <see cref="IWeakEvent{TEventHandler}"/> and <see cref="IParamsWeakEvent{TEventHandler}"/> store this instead of the original handler.
    /// This handler retain only a <see cref="WeakReference"/> to the target of the original handler.
    /// </summary>
    public interface IWeakEventHandler : IWeak
    {
        /// <summary>
        /// Invokes the handler on the original target.
        /// </summary>
        void Invoke();
    }

    /// <summary>
    /// Expose a property to evaluate if the object inside of a <see cref="WeakReference"/> is still alive or has been garbage collected.
    /// </summary>
    public interface IWeak
    {
        /// <summary>
        /// <c>True</c> if the object wrapped in a <see cref="WeakReference"/> is still alive, <c>False</c> otherwise.
        /// </summary>
        bool IsAlive { get; }
    }
#pragma warning restore CA1711
}
