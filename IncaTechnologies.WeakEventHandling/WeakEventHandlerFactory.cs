using IncaTechnologies.WeakEventHandling.Interfaces;
using System;

namespace IncaTechnologies.WeakEventHandling
{
    internal sealed class WeakEventHandlerFactory<TEventHandler> : IWeakEventHandelerFactory<TEventHandler> where TEventHandler : Delegate
    {
        public IWeakEventHandler<TParam1, TParam2, TParam3> CreateWeakEventHandler<TParam1, TParam2, TParam3>(TEventHandler eventHandler)
        {
            var eventHandlerType = eventHandler.GetType();
            var param1Type = eventHandler.Method.GetParameters()[0].ParameterType;
            var param2Type = eventHandler.Method.GetParameters()[1].ParameterType;
            var param3Type = eventHandler.Method.GetParameters()[2].ParameterType;

            //if the target is null is a static method and do not need to create a open delegate
            var weakHandlerType = eventHandler.Target switch
            {
                null => typeof(StaticWeakEventHandler<,,,>).MakeGenericType(eventHandlerType, param1Type, param2Type, param3Type),
                _ => typeof(WeakEventHandler<,,,,>).MakeGenericType(eventHandlerType, eventHandler.Target.GetType(), param1Type, param2Type, param3Type),
            };

            return (IWeakEventHandler<TParam1, TParam2, TParam3>)Activator.CreateInstance(weakHandlerType, eventHandler);
        }

        public IWeakEventHandler<TParam1, TParam2> CreateWeakEventHandler<TParam1, TParam2>(TEventHandler eventHandler)
        {
            var eventHandlerType = eventHandler.GetType();
            var param1Type = eventHandler.Method.GetParameters()[0].ParameterType;
            var param2Type = eventHandler.Method.GetParameters()[1].ParameterType;

            //if the target is null is a static method and do not need to create a open delegate
            var weakHandlerType = eventHandler.Target switch
            {
                null => typeof(StaticWeakEventHandler<,,>).MakeGenericType(eventHandlerType, param1Type, param2Type),
                _ => typeof(WeakEventHandler<,,,>).MakeGenericType(eventHandlerType, eventHandler.Target.GetType(), param1Type, param2Type),
            };

            return (IWeakEventHandler<TParam1, TParam2>)Activator.CreateInstance(weakHandlerType, eventHandler);
        }

        public IWeakEventHandler<TParam1> CreateWeakEventHandler<TParam1>(TEventHandler eventHandler)
        {
            var eventHandlerType = eventHandler.GetType();
            var param1Type = eventHandler.Method.GetParameters()[0].ParameterType;

            //if the target is null is a static method and do not need to create a open delegate
            var weakHandlerType = eventHandler.Target switch
            {
                null => typeof(StaticWeakEventHandler<,>).MakeGenericType(eventHandlerType, param1Type),
                _ => typeof(WeakEventHandler<,,>).MakeGenericType(eventHandlerType, eventHandler.Target.GetType(), param1Type),
            };

            return (IWeakEventHandler<TParam1>)Activator.CreateInstance(weakHandlerType, eventHandler);
        }

        public IWeakEventHandler CreateWeakEventHandler(TEventHandler eventHandler)
        {
            var eventHandlerType = eventHandler.GetType();

            //if the target is null is a static method and do not need to create a open delegate
            var weakHandlerType = eventHandler.Target switch
            {
                null => typeof(StaticWeakEventHandler<>).MakeGenericType(eventHandlerType),
                _ => typeof(WeakEventHandler<,>).MakeGenericType(eventHandlerType, eventHandler.Target.GetType()),
            };

            return (IWeakEventHandler)Activator.CreateInstance(weakHandlerType, eventHandler);
        }
    }
}
