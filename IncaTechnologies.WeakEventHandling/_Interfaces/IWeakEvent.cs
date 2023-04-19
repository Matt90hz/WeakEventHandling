using System;

namespace IncaTechnologies.WeakEventHandling.Interfaces
{
    /// <summary>
    /// Encapsulates functions to create a weak event.
    /// <exsample>
    /// <code>
    /// public class ExampleClass
    /// {
    ///     private readonly IWeakEvent&lt;EventHandler&lt;EventArgs&gt;&gt; _weakEvent = WeakEventFactory.CreateWeakEvent&lt;EventHandler&lt;EventArgs&gt;&gt;();
    ///
    ///     public event EventHandler&lt;EventArgs&gt; MyEvent
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
    ///      private void OnMyEvent(EventArgs args)
    ///      {
    ///         _weakEvent.Invoke(args);
    ///      }
    ///      
    ///      [...]
    ///      
    ///  }
    ///  </code>
    /// </exsample>
    /// </summary>
    /// <remarks>
    /// The difference between <see cref="IWeakEvent{TEventHandler}"/> and <see cref="IParamsWeakEvent{TEventHandler}"/> is that the first one do not have constraint on the Invoke.<br/>
    /// This make possible a more concise code during instantiation but it has an impact on performances due to casting and possible exceptions in case of passing wrong parameters to the Invoke method.
    /// </remarks>
    /// <typeparam name="TEventHandler">The type of the event handlet that the event will exspose.</typeparam>
    public interface IWeakEvent<TEventHandler> : IWeakEventAccessor<TEventHandler>, IWeakEventInvoke
        where TEventHandler : Delegate
    {

    }



}
