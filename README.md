# IncaTechnologies.WeakEventHandling

Create weak event to prevent memory leaks in you application due to objects with different scope.

## When to use it?

Singleton objects that expose events do not let the subscribers to be garbage collected. When you pass an instance method to an event by using the += operator, a delegate is created behind the scene and a reference to the object that contains that method is stored inside the delegate. If the subscriber has a life cicle shorter than the class that expose the event this can lead to a memory leak.

It is always better to unsubscribe from an event once the job is done. Unfortunately, this sometimes can add a lot of complexity to the project. The use of a weak event will prevent the memory leak.

## How to use it?

Just use the `WeakEventFactory` to create a weak event for the handler of your choice. Remember that the handler must have the signature of a void method with a maximum of three parameters.

> In the future, I might implement a way to have more parameters. 

### WeakEvent

This kind of event just needs the event handler type to be created. It is more concise than the `ParamsWeakEvent` but is less performant. Also the invoke method does not have constraints on the parameters. Be careful to pass the right parameters to the method or exceptions will be thrown.

It is advisable to use this kind of weak event with generic delegates since the instantiation can become verbose. Like `IParmasWeakEvent<MyEventHandler<MyClass, MyObject, string>, Myclass, MyObject, string>`, pretty verbose.

#### Example
```csharp
public class SingletonService
{
    private readonly IWeakEvent<EventHandler<EventArgs>> _weakEvent = WeakEventFactory.CreateWeakEvent<EventHandler<EventArgs>>();
    
    public event EventHandler<EventArgs> MyEvent
    {
        add
        {
            _weakEvent.Add(value);
        }
        remove
        {
            _weakEvent.Remove(value);
        }
    }
          
    private void OnMyEvent(EventArgs args)
    {
        _weakEvent.Invoke(args);
    }
          
    [...]
          
}
```

### ParamsWeakEvent

More performant and less error prone implementation.

#### Example
```csharp
public delegate void MyEventHandler(ExampleClass sender, int value);
     
public class SingletonService
{
    private readonly IParamsWeakEvent<MyEventHandler, ExampleClass, int> _weakEvent = WeakEventFactory.CreateParamsWeakEvent<MyEventHandler, ExampleClass, int>();
    
    public event MyEventHandler MyEvent
    {
        add
        {
            _weakEvent.Add(value);
        }
        remove
        {
            _weakEvent.Remove(value);
        }
      }
      
     private void OnMyEvent(int value)
     {
        _weakEvent.Invoke(this, value);
     }
     
    [...]

}
```

### WeakSubscriber

This is a solution in case you are not in control or you do not want to edit the class that expose the event. 

**Be careful the object that subscribe to the event will be garbage collected but the `WeakSubscriber` is an object itself and it will leak. So, it makes sense to use it only for heavy objects that want to subscribe to an event and have a shorter life span than the event publisher.**

#### Example
```csharp
public class MyTransientClass
{
    public byte[]? MyFatImage { get; set; }

    public MyTransientClass(ISingletonService service)
    {
        service.SomethingChanged += WeakSubscriberFactory.Create<EventHandler<Something>>(SingletonService_SomethingChanged).WeakHandler;
    }

    private void SingletonService_SomethingChanged(object? sender, Something something)
    {
        [...]
    }
}
```

## How about the performances?

I performed some benchmarks. Here the results:

![Image](https://raw.githubusercontent.com/Matt90hz/WeakEventHandling/master/IncaTechnologies.WeakEventHandling/Benchmarks.jpg)

### Disclaimer

For comparison purposes, I used [ThomasLevesque WeakEvent](https://github.com/thomaslevesque/WeakEvent/) since it looks to be the most popular on NuGet.org. But I am not affiliated to them and none of their code has been used to create this library.

If anyone has any complain about the use of this package in my benchmarks please open an [issue](https://github.com/Matt90hz/WeakEventHandling/issues) on GitHub or send an email and I will immediately remove any refererence to this library.

## Contribution

Do you like this library and you want to add or change something? Feel free to do it, just create your pull request on [GitHub](https://github.com/Matt90hz/WeakEventHandling).