using System;

namespace IncaTechnologies.WeakEventHandling.Interfaces
{

    /// <summary>
    /// Encapsulates functions to create a weak event.
    /// <exsample>
    /// <code>
    /// 
    /// public delegate void MyEventHandler(ExampleClass sender, int value, string name);
    /// 
    /// public class ExampleClass
    /// {
    ///     private readonly IParamsWeakEvent&lt;MyEventHandler, ExampleClass, int, string&gt; _weakEvent = WeakEventFactory.CreateParamsWeakEvent&lt;MyEventHandler, ExampleClass, int, string&gt;();
    ///
    ///     public event MyEventHandler MyEvent
    ///     {
    ///         add
    ///         {
    ///             _weakEvent.Add(value);
    ///         }
    ///         remove
    ///         {
    ///             _weakEvent.Remove(value);
    ///         }
    ///      }
    ///      
    ///      private void OnMyEvent(int value, string name)
    ///      {
    ///         _weakEvent.Invoke(this, value, name);
    ///      }
    ///      
    ///      [...]
    ///     
    ///  }
    ///  </code>
    /// </exsample>
    /// </summary>
    /// <typeparam name="TEventHandler">The type of the event handlet that the event will exspose.</typeparam>
    /// <typeparam name="TParam1">First parameter type of the event handler.</typeparam>
    /// <typeparam name="TParam2">Second parameter type of the event handler.</typeparam>
    /// <typeparam name="TParam3">Third parameter type of the event handler.</typeparam>
    public interface IParamsWeakEvent<TEventHandler, TParam1, TParam2, TParam3> : IWeakEventAccessor<TEventHandler>, IWeakEventInvokeParams<TParam1, TParam2, TParam3>
        where TEventHandler : Delegate
    {

    }


    /// <summary>
    /// Encapsulates functions to create a weak event.
    /// <exsample>
    /// <code>
    /// 
    /// public delegate void MyEventHandler(ExampleClass sender, int value);
    /// 
    /// public class ExampleClass
    /// {
    ///     private readonly IParamsWeakEvent&lt;MyEventHandler, ExampleClass, int&gt; _weakEvent = WeakEventFactory.CreateParamsWeakEvent&lt;MyEventHandler, ExampleClass, int&gt;();
    ///
    ///     public event MyEventHandler MyEvent
    ///     {
    ///         add
    ///         {
    ///             _weakEvent.Add(value);
    ///         }
    ///         remove
    ///         {
    ///             _weakEvent.Remove(value);
    ///         }
    ///      }
    ///      
    ///      private void OnMyEvent(int value)
    ///      {
    ///         _weakEvent.Invoke(this, value);
    ///      }
    ///      
    ///      [...]
    ///     
    ///  }
    ///  </code>
    /// </exsample>
    /// </summary>
    /// <typeparam name="TEventHandler">The type of the event handlet that the event will exspose.</typeparam>
    /// <typeparam name="TParam1">First parameter type of the event handler.</typeparam>
    /// <typeparam name="TParam2">Second parameter type of the event handler.</typeparam>
    public interface IParamsWeakEvent<TEventHandler, TParam1, TParam2> : IWeakEventAccessor<TEventHandler>, IWeakEventInvokeParams<TParam1, TParam2>
        where TEventHandler : Delegate
    {

    }

    /// <summary>
    /// Encapsulates functions to create a weak event.
    /// <exsample>
    /// <code>
    /// 
    /// public delegate void MyEventHandler(ExampleClass sender);
    /// 
    /// public class ExampleClass
    /// {
    ///     private readonly IParamsWeakEvent&lt;MyEventHandler, int&gt; _weakEvent = WeakEventFactory.CreateParamsWeakEvent&lt;MyEventHandler, int&gt;();
    ///
    ///     public event MyEventHandler MyEvent
    ///     {
    ///         add
    ///         {
    ///             _weakEvent.Add(value);
    ///         }
    ///         remove
    ///         {
    ///             _weakEvent.Remove(value);
    ///         }
    ///      }
    ///      
    ///      private void OnMyEvent()
    ///      {
    ///         _weakEvent.Invoke(this);
    ///      }
    ///      
    ///      [...]
    ///     
    ///  }
    ///  </code>
    /// </exsample>
    /// </summary>
    /// <typeparam name="TEventHandler">The type of the event handlet that the event will exspose.</typeparam>
    /// <typeparam name="TParam1">First parameter type of the event handler.</typeparam>
    public interface IParamsWeakEvent<TEventHandler, TParam1> : IWeakEventAccessor<TEventHandler>, IWeakEventInvokeParams<TParam1>
        where TEventHandler : Delegate
    {

    }

    /// <summary>
    /// Encapsulates functions to create a weak event.
    /// <exsample>
    /// <code>
    /// 
    /// public delegate void MyEventHandler();
    /// 
    /// public class ExampleClass
    /// {
    ///     private readonly IParamsWeakEvent&lt;MyEventHandler&gt; _weakEvent = WeakEventFactory.CreateParamsWeakEvent&lt;MyEventHandler&gt;();
    ///
    ///     public event MyEventHandler MyEvent
    ///     {
    ///         add
    ///         {
    ///             _weakEvent.Add(value);
    ///         }
    ///         remove
    ///         {
    ///             _weakEvent.Remove(value);
    ///         }
    ///      }
    ///      
    ///      private void OnMyEvent()
    ///      {
    ///         _weakEvent.Invoke();
    ///      }
    ///      
    ///      [...]
    ///      
    ///  }
    ///  </code>
    /// </exsample>
    /// </summary>
    /// <typeparam name="TEventHandler">The type of the event handlet that the event will exspose.</typeparam>
    public interface IParamsWeakEvent<TEventHandler> : IWeakEventAccessor<TEventHandler>, IWeakEventInvokeParams
        where TEventHandler : Delegate
    {

    }

}
