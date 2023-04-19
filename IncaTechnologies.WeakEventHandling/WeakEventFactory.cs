using IncaTechnologies.WeakEventHandling.Interfaces;
using System;

namespace IncaTechnologies.WeakEventHandling
{
    public static class WeakEventFactory
    {
        public static IParamsWeakEvent<TEventHandler, TParam1, TParam2, TParam3> CreateParamsWeakEvent<TEventHandler, TParam1, TParam2, TParam3>() where TEventHandler : Delegate
        {
            return new ParamsWeakEvent<TEventHandler, TParam1, TParam2, TParam3>(new WeakEventHandlerFactory<TEventHandler>());
        }

        public static IParamsWeakEvent<TEventHandler, TParam1, TParam2> CreateParamsWeakEvent<TEventHandler, TParam1, TParam2>() where TEventHandler : Delegate
        {
            return new ParamsWeakEvent<TEventHandler, TParam1, TParam2>(new WeakEventHandlerFactory<TEventHandler>());
        }

        public static IParamsWeakEvent<TEventHandler, TParam1> CreateParamsWeakEvent<TEventHandler, TParam1>() where TEventHandler : Delegate
        {
            return new ParamsWeakEvent<TEventHandler, TParam1>(new WeakEventHandlerFactory<TEventHandler>());
        }

        public static IParamsWeakEvent<TEventHandler> CreateParamsWeakEvent<TEventHandler>() where TEventHandler : Delegate
        {
            return new ParamsWeakEvent<TEventHandler>(new WeakEventHandlerFactory<TEventHandler>());
        }

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
