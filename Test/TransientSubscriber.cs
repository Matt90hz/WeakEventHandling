using IncaTechnologies.WeakEventHandling;
using IncaTechnologies.WeakEventHandling.Interfaces;

public class TransientSubscriber
{
    private readonly SingletonService _singletonService;
    private IWeakSubscriber<EventHandler<SenderEventArgs>>? _subscriber;

    public TransientSubscriber(SingletonService service)
    {
        _singletonService = service;       
    }

    public void Subscribe()
    {
        _singletonService.ThomasLevesque_WeakEvent += EventCallback;
        _singletonService.IncaTechnologies_ParamsWeakEvent += EventCallback;
        _singletonService.IncaTechnologies_WeakEvent += EventCallback;

#if DEBUG
        _singletonService.IncaTechnologies_ParamsWeakEvent += StaticEventCallback;
        _singletonService.IncaTechnologies_WeakEvent += StaticEventCallback;
#endif

        _subscriber = WeakSubscriberFactory.Create<EventHandler<SenderEventArgs>>(EventCallback);
        _singletonService.IncaTechnologies_WeakSubcriberHandler += _subscriber.WeakHandler;

#if !DEBUG
        _singletonService.CLR_Event += EventCallback;
#endif
    }

    private void EventCallback(object? sender, SenderEventArgs e)
    {
#if DEBUG
        Console.WriteLine(e.Sender);
#endif
    }

    private static void StaticEventCallback(object? sender, SenderEventArgs e)
    {
#if DEBUG
        Console.WriteLine("STATIC " + e.Sender);
#endif
    }

    public void Unsubscribe() 
    {
        _singletonService.ThomasLevesque_WeakEvent -= EventCallback;
        _singletonService.IncaTechnologies_ParamsWeakEvent -= EventCallback;
        _singletonService.IncaTechnologies_WeakEvent -= EventCallback;

#if DEBUG
        _singletonService.IncaTechnologies_ParamsWeakEvent -= StaticEventCallback;
        _singletonService.IncaTechnologies_WeakEvent -= StaticEventCallback;
#endif

        _singletonService.IncaTechnologies_WeakSubcriberHandler -= _subscriber?.WeakHandler;
        _subscriber = null;
#if !DEBUG
        _singletonService.CLR_Event -= EventCallback;
#endif
    }

    ~TransientSubscriber()
    {
#if DEBUG
        Console.WriteLine($"TransientSubscriber {GetHashCode()} garbedge collected.");
#endif
    }

}




