using WeakEvent;
using IncaTechnologies.WeakEventHandling;
using IncaTechnologies.WeakEventHandling.Interfaces;

public class SingletonService
{
    private readonly WeakEventSource<SenderEventArgs> _eventSource = new();
    private readonly IParamsWeakEvent<EventHandler<SenderEventArgs>, object?, SenderEventArgs> _eventParams = WeakEventFactory.CreateParamsWeakEvent<EventHandler<SenderEventArgs>, object?, SenderEventArgs>();
    private readonly IWeakEvent<EventHandler<SenderEventArgs>> _event = WeakEventFactory.CreateWeakEvent<EventHandler<SenderEventArgs>>();

    public event EventHandler<SenderEventArgs> ThomasLevesque_WeakEvent
    {
        add
        {
            _eventSource.Subscribe(value);
        }
        remove
        {
            _eventSource.Unsubscribe(value);
        }
    }

    public event EventHandler<SenderEventArgs> IncaTechnologies_ParamsWeakEvent
    {
        add
        {
            _eventParams.Add(value);
        }
        remove
        {
            _eventParams.Remove(value);
        }
    }

    public event EventHandler<SenderEventArgs> IncaTechnologies_WeakEvent
    {
        add
        {
            _event.Add(value);
        }
        remove
        {
            _event.Remove(value);
        }
    }

    public event EventHandler<SenderEventArgs>? CLR_Event;

    public event EventHandler<SenderEventArgs>? IncaTechnologies_WeakSubcriberHandler;

    public void Invoke_ThomasLevesque_WeakEvent(int i = 1)
    {
        while(i > 0)
        {
            _eventSource.Raise(this, new SenderEventArgs("ThomasLevesque_WeakEvent"));
            i--;
        }
        
    }

    public void Invoke_IncaTechnologies_ParamsWeakEvent(int i = 1)
    {
        while (i > 0)
        {
            _eventParams.Invoke(this, new SenderEventArgs("IncaTechnologies_ParamsWeakEvent"));
            i--;
        }
    }

    public void Invoke_IncaTechnologies_WeakEvent(int i = 1)
    {
        while (i > 0)
        {
            _event.Invoke(this, new SenderEventArgs("IncaTechnologies_WeakEvent"));
            i--;
        }
    }

    public void Invoke_IncaTechnologies_WeakSubcriberHandler(int i = 1)
    {
        while (i > 0)
        {
            IncaTechnologies_WeakSubcriberHandler?.Invoke(this, new SenderEventArgs("IncaTechnologies_WeakSubcriberHandler"));
            i--;
        }
    }

    public void Invoke_CLR_Event(int i = 1)
    {
        while (i > 0)
        {
            CLR_Event?.Invoke(this, new SenderEventArgs("CLR_Event"));
            i--;
        }
    }
}



