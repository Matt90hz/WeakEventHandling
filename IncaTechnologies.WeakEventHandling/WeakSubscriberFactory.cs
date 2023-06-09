﻿using IncaTechnologies.WeakEventHandling.Interfaces;
using System;

namespace IncaTechnologies.WeakEventHandling
{
    /// <summary>
    /// Factory for <see cref="IWeakSubscriber{TEventHandler}"/>.
    /// </summary>
    public static class WeakSubscriberFactory
    {
        /// <summary>
        /// Creates an <see cref="IWeakSubscriber{TEventHandler}"/>.
        /// </summary>
        /// <typeparam name="TEventHandler">Type of the handler of the event to subscribe to.</typeparam>
        /// <param name="eventHandler">Delegate or method callback the will be invoked when the event triggers.</param>
        /// <returns>A new <see cref="IWeakSubscriber{TEventHandler}"/></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static IWeakSubscriber<TEventHandler> Create<TEventHandler>(TEventHandler eventHandler) where TEventHandler : Delegate
        {
            var parameters = eventHandler.Method.GetParameters();

            var handlerType = eventHandler.GetType();
            var ownerType = eventHandler.Target.GetType();

            var weakSubcriberType = parameters.Length switch
            {
                0 => typeof(WeakSubscriber<,>).MakeGenericType(handlerType, ownerType),
                1 => typeof(WeakSubscriber<,,>).MakeGenericType(handlerType, ownerType, parameters[0].ParameterType),
                2 => typeof(WeakSubscriber<,,,>).MakeGenericType(handlerType, ownerType, parameters[0].ParameterType, parameters[1].ParameterType),
                3 => typeof(WeakSubscriber<,,,,>).MakeGenericType(handlerType, ownerType, parameters[0].ParameterType, parameters[1].ParameterType, parameters[2].ParameterType),
                _ => throw new NotImplementedException("The event handler cannot have more than 3 parameter.")
            };

            return parameters.Length switch
            {
                0 => (IWeakSubscriber<TEventHandler>)Activator.CreateInstance(weakSubcriberType, eventHandler),
                1 => (IWeakSubscriber<TEventHandler>)Activator.CreateInstance(weakSubcriberType, eventHandler),
                2 => (IWeakSubscriber<TEventHandler>)Activator.CreateInstance(weakSubcriberType, eventHandler),
                3 => (IWeakSubscriber<TEventHandler>)Activator.CreateInstance(weakSubcriberType, eventHandler),
                _ => throw new NotImplementedException("The event handler cannot have more than 3 parameter.")
            };
        }
    }
}
