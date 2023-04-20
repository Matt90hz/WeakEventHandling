using IncaTechnologies.WeakEventHandling.Interfaces;
using System;

namespace IncaTechnologies.WeakEventHandling
{
    /// <summary>
    /// Factory to create <see cref="IWeakEvent{TEventHandler}"/> and <see cref="IParamsWeakEvent{TEventHandler}"/>.
    /// </summary>
    public static class WeakEventFactory
    {
        /// <summary>
        /// Creates an instance of <see cref="IParamsWeakEvent{TEventHandler, TParam1, TParam2, TParam3}"/>.
        /// </summary>
        /// <typeparam name="TEventHandler">Type of the event handler.</typeparam>
        /// <typeparam name="TParam1">Frist parameter of the event handler.</typeparam>
        /// <typeparam name="TParam2">Second parameter of the event handler.</typeparam>
        /// <typeparam name="TParam3">Third parameter of the event handler.</typeparam>
        /// <returns>A new instance of <see cref="IParamsWeakEvent{TEventHandler, TParam1, TParam2, TParam3}"/></returns>
        public static IParamsWeakEvent<TEventHandler, TParam1, TParam2, TParam3> CreateParamsWeakEvent<TEventHandler, TParam1, TParam2, TParam3>() where TEventHandler : Delegate
        {
            return new ParamsWeakEvent<TEventHandler, TParam1, TParam2, TParam3>(new WeakEventHandlerFactory<TEventHandler>());
        }

        /// <summary>
        /// Creates an instance of <see cref="IParamsWeakEvent{TEventHandler, TParam1, TParam2}"/>.
        /// </summary>
        /// <typeparam name="TEventHandler">Type of the event handler.</typeparam>
        /// <typeparam name="TParam1">Frist parameter of the event handler.</typeparam>
        /// <typeparam name="TParam2">Second parameter of the event handler.</typeparam>
        /// <returns>A new instance of <see cref="IParamsWeakEvent{TEventHandler, TParam1, TParam2}"/></returns>
        public static IParamsWeakEvent<TEventHandler, TParam1, TParam2> CreateParamsWeakEvent<TEventHandler, TParam1, TParam2>() where TEventHandler : Delegate
        {
            return new ParamsWeakEvent<TEventHandler, TParam1, TParam2>(new WeakEventHandlerFactory<TEventHandler>());
        }

        /// <summary>
        /// Creates an instance of <see cref="IParamsWeakEvent{TEventHandler, TParam1}"/>.
        /// </summary>
        /// <typeparam name="TEventHandler">Type of the event handler.</typeparam>
        /// <typeparam name="TParam1">Frist parameter of the event handler.</typeparam>
        /// <returns>A new instance of <see cref="IParamsWeakEvent{TEventHandler, TParam1}"/></returns>
        public static IParamsWeakEvent<TEventHandler, TParam1> CreateParamsWeakEvent<TEventHandler, TParam1>() where TEventHandler : Delegate
        {
            return new ParamsWeakEvent<TEventHandler, TParam1>(new WeakEventHandlerFactory<TEventHandler>());
        }

        /// <summary>
        /// Creates an instance of <see cref="IParamsWeakEvent{TEventHandler}"/>.
        /// </summary>
        /// <typeparam name="TEventHandler">Type of the event handler.</typeparam>
        /// <returns>A new instance of <see cref="IParamsWeakEvent{TEventHandler}"/></returns>
        public static IParamsWeakEvent<TEventHandler> CreateParamsWeakEvent<TEventHandler>() where TEventHandler : Delegate
        {
            return new ParamsWeakEvent<TEventHandler>(new WeakEventHandlerFactory<TEventHandler>());
        }

        /// <summary>
        /// Creates an instance of <see cref="IWeakEvent{TEventHandler}"/>.
        /// </summary>
        /// <typeparam name="TEventHandler">Type of the event handler.</typeparam>
        /// <returns>A new instance of <see cref="IWeakEvent{TEventHandler}"/></returns>
        public static IWeakEvent<TEventHandler> CreateWeakEvent<TEventHandler>() where TEventHandler : Delegate
        {
            var eventhandlerFactory = new WeakEventHandlerFactory<TEventHandler>();

            var handlerType = typeof(TEventHandler);

            var weakEventType = handlerType.GetMethod("Invoke").GetParameters().Length switch
            {
                0 => typeof(WeakEvent<TEventHandler>),
                1 => typeof(WeakEvent<,>).MakeGenericType(handlerType, handlerType.GetMethod("Invoke").GetParameters()[0].ParameterType),
                2 => typeof(WeakEvent<,,>).MakeGenericType(handlerType, handlerType.GetMethod("Invoke").GetParameters()[0].ParameterType, handlerType.GetMethod("Invoke").GetParameters()[1].ParameterType),
                3 => typeof(WeakEvent<,,,>).MakeGenericType(handlerType, handlerType.GetMethod("Invoke").GetParameters()[0].ParameterType, handlerType.GetMethod("Invoke").GetParameters()[1].ParameterType, handlerType.GetMethod("Invoke").GetParameters()[2].ParameterType),
                _ => throw new NotImplementedException("Maximum 3 parameters for the event handler.")
            };

            return (IWeakEvent<TEventHandler>)Activator.CreateInstance(weakEventType, eventhandlerFactory);
        }
    }
}
