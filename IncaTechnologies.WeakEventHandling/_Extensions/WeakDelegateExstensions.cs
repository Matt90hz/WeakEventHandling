using System;

namespace IncaTechnologies.WeakEventHandling.Extensions
{
    /// <summary>
    /// Open delegate for event handlers with three parameters.
    /// </summary>
    /// <typeparam name="TOwner">Closed delegate targer type.</typeparam>
    /// <typeparam name="TParam1">First parameter.</typeparam>
    /// <typeparam name="TParam2">Second paramenter.</typeparam>
    /// <typeparam name="TParam3">Third parameter.</typeparam>
    /// <param name="owner">Closed delegate target.</param>
    /// <param name="param1">Closed delegate first parameter.</param>
    /// <param name="param2">Closed delegate second parameter.</param>
    /// <param name="param3">Closed delegate third parameter.</param>
    internal delegate void WeakDelegate<TOwner, TParam1, TParam2, TParam3>(TOwner owner, TParam1 param1, TParam2 param2, TParam3 param3);

    /// <summary>
    /// Open delegate for event handlers with two parameters.
    /// </summary>
    /// <typeparam name="TOwner">Closed delegate targer type.</typeparam>
    /// <typeparam name="TParam1">First parameter.</typeparam>
    /// <typeparam name="TParam2">Second paramenter.</typeparam>
    /// <param name="owner">Closed delegate target.</param>
    /// <param name="param1">Closed delegate first parameter.</param>
    /// <param name="param2">Closed delegate second parameter.</param>
    internal delegate void WeakDelegate<TOwner, TParam1, TParam2>(TOwner owner, TParam1 param1, TParam2 param2);

    /// <summary>
    /// Open delegate for event handlers with one parameter.
    /// </summary>
    /// <typeparam name="TOwner">Closed delegate targer type.</typeparam>
    /// <typeparam name="TParam">First parameter.</typeparam>
    /// <param name="owner">Closed delegate target.</param>
    /// <param name="param">Closed delegate first parameter.</param>
    internal delegate void WeakDelegate<TOwner, TParam>(TOwner owner, TParam param);

    /// <summary>
    /// Open delegate for event handlers with no parameters.
    /// </summary>
    /// <typeparam name="TOwner">Closed delegate targer type.</typeparam>
    /// <param name="owner">Closed delegate target.</param>
    internal delegate void WeakDelegate<TOwner>(TOwner owner);

    internal static class WeakDelegateExstensions
    {
        /// <summary>
        /// Creates an open delegate for event hadlers form a closed one.
        /// </summary>
        /// <typeparam name="TEventHandler">Closed event handler type.</typeparam>
        /// <typeparam name="TOwner">Closed event handelr target.</typeparam>
        /// <typeparam name="TParam1">First paramete type of the closed handler.</typeparam>
        /// <typeparam name="TParam2">Second paramete type of the closed handler.</typeparam>
        /// <typeparam name="TParam3">Third paramete type of the closed handler.</typeparam>
        /// <param name="eventHandler">Closed event handler.</param>
        /// <returns>Open event handler.</returns>
        /// <exception cref="ArgumentException">
        /// Throws if the <paramref name="eventHandler"/> do not rappresent a void method with three parameters of type <typeparamref name="TParam1"/>, <typeparamref name="TParam2"/> and <typeparamref name="TParam3"/>.
        /// </exception>
        public static WeakDelegate<TOwner, TParam1, TParam2, TParam3> CreateOpenDelegate<TEventHandler, TOwner, TParam1, TParam2, TParam3>(this TEventHandler eventHandler)
            where TEventHandler : Delegate
            where TOwner : class
        {
            try
            {
                return (WeakDelegate<TOwner, TParam1, TParam2, TParam3>)Delegate.CreateDelegate(typeof(WeakDelegate<TOwner, TParam1, TParam2, TParam3>), null, eventHandler.Method);
            }
            catch (Exception e)
            {
                throw new ArgumentException($"The event handler must be a void method with 3 parameters of type {typeof(TParam1).Name}, {typeof(TParam2).Name} and {typeof(TParam3).Name}.", nameof(eventHandler), e);
            }
        }

        /// <summary>
        /// Creates an open delegate for event hadlers form a closed one.
        /// </summary>
        /// <typeparam name="TEventHandler">Closed event handler type.</typeparam>
        /// <typeparam name="TOwner">Closed event handelr target.</typeparam>
        /// <typeparam name="TParam1">First paramete type of the closed handler.</typeparam>
        /// <typeparam name="TParam2">Second paramete type of the closed handler.</typeparam>
        /// <param name="eventHandler">Closed event handler.</param>
        /// <returns>Open event handler.</returns>
        /// <exception cref="ArgumentException">
        /// Throws if the <paramref name="eventHandler"/> do not rappresent a void method with two parameters of type <typeparamref name="TParam1"/> and <typeparamref name="TParam2"/>.
        /// </exception>
        public static WeakDelegate<TOwner, TParam1, TParam2> CreateOpenDelegate<TEventHandler, TOwner, TParam1, TParam2>(this TEventHandler eventHandler)
            where TEventHandler : Delegate
            where TOwner : class
        {
            try
            {
                return (WeakDelegate<TOwner, TParam1, TParam2>)Delegate.CreateDelegate(typeof(WeakDelegate<TOwner, TParam1, TParam2>), null, eventHandler.Method);
            }
            catch (Exception e)
            {
                throw new ArgumentException($"The event handler must be a void method with 2 parameters of type {typeof(TParam1).Name} and {typeof(TParam2).Name}.", nameof(eventHandler), e);
            }
        }

        /// <summary>
        /// Creates an open delegate for event hadlers form a closed one.
        /// </summary>
        /// <typeparam name="TEventHandler">Closed event handler type.</typeparam>
        /// <typeparam name="TOwner">Closed event handelr target.</typeparam>
        /// <typeparam name="TParam1">First paramete type of the closed handler.</typeparam>
        /// <param name="eventHandler">Closed event handler.</param>
        /// <returns>Open event handler.</returns>
        /// <exception cref="ArgumentException">
        /// Throws if the <paramref name="eventHandler"/> do not rappresent a void method with one parameter of type <typeparamref name="TParam1"/>.
        /// </exception>
        public static WeakDelegate<TOwner, TParam1> CreateOpenDelegate<TEventHandler, TOwner, TParam1>(this TEventHandler eventHandler)
            where TEventHandler : Delegate
            where TOwner : class
        {
            try
            {
                return (WeakDelegate<TOwner, TParam1>)Delegate.CreateDelegate(typeof(WeakDelegate<TOwner, TParam1>), null, eventHandler.Method);
            }
            catch (Exception e)
            {
                throw new ArgumentException($"The event handler must be a void method with a parameter of type {typeof(TParam1).Name}.", nameof(eventHandler), e);
            }
        }

        /// <summary>
        /// Creates an open delegate for event hadlers form a closed one.
        /// </summary>
        /// <typeparam name="TEventHandler">Closed event handler type.</typeparam>
        /// <typeparam name="TOwner">Closed event handelr target.</typeparam>
        /// <param name="eventHandler">Closed event handler.</param>
        /// <returns>Open event handler.</returns>
        /// <exception cref="ArgumentException">
        /// Throws if the <paramref name="eventHandler"/> do not rappresent a void method with no parameters.
        /// </exception>
        public static WeakDelegate<TOwner> CreateOpenDelegate<TEventHandler, TOwner>(this TEventHandler eventHandler)
            where TEventHandler : Delegate
            where TOwner : class
        {
            try
            {
                return (WeakDelegate<TOwner>)Delegate.CreateDelegate(typeof(WeakDelegate<TOwner>), null, eventHandler.Method);
            }
            catch (Exception e)
            {
                throw new ArgumentException($"The event handler must be a void method with no parameters.", nameof(eventHandler), e);
            }
        }
    }
}
