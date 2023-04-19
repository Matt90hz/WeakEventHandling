
public class Test
{
    private readonly SingletonService _singletonService;
    private readonly List<TransientSubscriber> _subscribers = new List<TransientSubscriber>();

    public Test(SingletonService singletonService)
    {
        _singletonService = singletonService;
    }

    public void Run()
    {
        CreateSubscribers(3);
        SubscribeToEvents();
        InvokeEvents();
        KillSubscribers();
        GCCollect();
        InvokeEvents();
    }

    private void CreateSubscribers(int num = 1)
    {
        _subscribers.AddRange(Enumerable.Range(1, num).Select(_ => new TransientSubscriber(_singletonService)));
        Console.WriteLine($"{num} TransientSubscrbers created.");
        Console.WriteLine();

    }

    private void SubscribeToEvents()
    {
        _subscribers.ForEach(s => s.Subscribe());
        Console.WriteLine("Subscribed to events.");
        Console.WriteLine();
    }

    private void InvokeEvents()
    {
        Console.WriteLine("EVENT INVOKE START");
        _singletonService.Invoke_IncaTechnologies_ParamsWeakEvent();
        _singletonService.Invoke_IncaTechnologies_WeakEvent();
        _singletonService.Invoke_ThomasLevesque_WeakEvent();
        _singletonService.Invoke_IncaTechnologies_WeakSubcriberHandler();
        _singletonService.Invoke_CLR_Event();
        Console.WriteLine("EVENT INVOKE FINISHED");
        Console.WriteLine();

    }

    private void UnsubscribeFromEvents()
    {
        _subscribers.ForEach(s => s.Unsubscribe());
        Console.WriteLine("Unsubscribed from events.");
        Console.WriteLine();

    }

    private void KillSubscribers()
    {
        _subscribers.Clear();
        Console.WriteLine("Subscribers cleared.");
        Console.WriteLine();

    }

    private void GCCollect()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        Console.WriteLine("Garbage collectected.");
        Console.WriteLine();
    }
}




