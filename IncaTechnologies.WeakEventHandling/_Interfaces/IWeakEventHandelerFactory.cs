using System;

namespace IncaTechnologies.WeakEventHandling.Interfaces
{
    /// <summary>
    /// Manage the creation of <see cref="IWeakEventHandler"/>.
    /// </summary>
    /// <typeparam name="TEventHandler"></typeparam>
    public interface IWeakEventHandelerFactory<TEventHandler> where TEventHandler : Delegate
    {
        /// <summary>
        /// Creates an <see cref="IWeakEventHandler{TParam1, TParam2, TParam3}"/>.
        /// </summary>
        /// <typeparam name="TParam1">First parameter of the <paramref name="eventHandler"/></typeparam>
        /// <typeparam name="TParam2">Second parameter of the <paramref name="eventHandler"/></typeparam>
        /// <typeparam name="TParam3">Third parameter of the <paramref name="eventHandler"/></typeparam>
        /// <param name="eventHandler">The signature of the <paramref name="eventHandler"/> must match a void method with three parameters of type <typeparamref name="TParam1"/>, <typeparamref name="TParam2"/> and <typeparamref name="TParam3"/>.</param>
        /// <returns>A new <see cref="IWeakEventHandler{TParam1, TParam2, TParam3}"/></returns>
        IWeakEventHandler<TParam1, TParam2, TParam3> CreateWeakEventHandler<TParam1, TParam2, TParam3>(TEventHandler eventHandler);

        /// <summary>
        /// Creates an <see cref="IWeakEventHandler{TParam1, TParam2}"/>.
        /// </summary>
        /// <typeparam name="TParam1">First parameter of the <paramref name="eventHandler"/></typeparam>
        /// <typeparam name="TParam2">Second parameter of the <paramref name="eventHandler"/></typeparam>
        /// <param name="eventHandler">The signature of the <paramref name="eventHandler"/> must match a void method with two parameters of type <typeparamref name="TParam1"/> and <typeparamref name="TParam2"/>.</param>
        /// <returns>A new <see cref="IWeakEventHandler{TParam1, TParam2}"/></returns>
        IWeakEventHandler<TParam1, TParam2> CreateWeakEventHandler<TParam1, TParam2>(TEventHandler eventHandler);

        /// <summary>
        /// Creates an <see cref="IWeakEventHandler{TParam1}"/>.
        /// </summary>
        /// <typeparam name="TParam1">First parameter of the <paramref name="eventHandler"/></typeparam>
        /// <param name="eventHandler">The signature of the <paramref name="eventHandler"/> must match a void method with a parameter of type <typeparamref name="TParam1"/>.</param>
        /// <returns>A new <see cref="IWeakEventHandler{TParam1}"/></returns>
        IWeakEventHandler<TParam1> CreateWeakEventHandler<TParam1>(TEventHandler eventHandler);

        /// <summary>
        /// Creates an <see cref="IWeakEventHandler"/>.
        /// </summary>
        /// <param name="eventHandler">The signature of the <paramref name="eventHandler"/> must match a void method with no parameters.</param>
        /// <returns>A new <see cref="IWeakEventHandler{TParam1, TParam2, TParam3}"/></returns>
        IWeakEventHandler CreateWeakEventHandler(TEventHandler eventHandler);
    }
}
