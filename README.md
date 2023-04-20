# IncaTechnologies.WeakEventHandling

Create weak event to prevent memory leaks in you application due to objects with differnt scope.

## When to ues it?

Singleton objects that expose events do not let the subscribers to be garbage collected. When you pass an instance method to an event by using the += operator a delegate get created form that behind the scene and a referece to the object that contains that method is stored inside the delegate. If the subscriber has a life cicle shorter than the class that exspose the event this can lead to a memory leak.

Is alway better to unsubscribe to event once the job is done but this sometime is can add a lot of complexity to the project. Use a weak event will prevent the memory leak.

## How to use it

Just use the `WeakEventFactory` to create a weak event for the handler of your choice. Remember that the handler must have the signature of a void method with a meximum of three parameters.

> In the future I might implement a way to have more parameters. 

### WeakEvent

This kind of event just need the event handler type to be created, so is more concise than the `ParamsWeakEvent` but is less performat and the invoke method do not have contraint on the parameters. Be carful to pass the right parameters to the method or exceptions will be thorwn.

Is better use this kind of weak event with generics delegates since the instantiation can became verbose. Like `IParmasWeakEvent<MyEventHandler<MyClass, MyObject, string>, Myclass, MyObject, string>`, pretty verbose.

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

Most performat and less error prone implementation.

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

**Be careful the object that subscribe to the event will be garbage collected but the `WeakSubscriber` is an object it self and it will leak. So make sense to use this only for heavy objects that want subscribe to an event and have a shorter life span than the event publisher.**

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

I performed some banchmarks here the result:

![Image](https://raw.githubusercontent.com/Matt90hz/WeakEventHandling/master/IncaTechnologies.WeakEventHandling/Benchmarks.jpg)

### Disclaimer

Just to have mean of comparison I used [ThomasLevesque WeakEvent](https://github.com/thomaslevesque/WeakEvent/) since it looks to be the most popular on NuGet.org. But I am not affiliated to them and none of their code has been used to create this library.

If anyone has any complain about the use of this package in my benchmarks plaese open an [issue](https://github.com/Matt90hz/WeakEventHandling/issues) on GitHub or sand an email and I will immediatly remove any refererence to this library.

## Contribution

You like this library and you want to add or change something. Feel free to do it, just create your pull request on [GitHub](https://github.com/Matt90hz/WeakEventHandling).