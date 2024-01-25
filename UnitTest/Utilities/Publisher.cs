using IncaTechnologies.WeakEventHandling;
using IncaTechnologies.WeakEventHandling.Interfaces;

namespace UnitTest.Utilities;

public class Publisher
{
    public IWeakEvent<EventHandler> _WeakEvent { get; } = WeakEventFactory.CreateWeakEvent<EventHandler>();

    public IParamsWeakEvent<EventHandler, object, EventArgs> _ParamsWeakEvent { get; } = WeakEventFactory.CreateParamsWeakEvent<EventHandler, object, EventArgs>();

    public event EventHandler? Event;

    public event EventHandler WeakEvent
    {
        add => _WeakEvent.Add(value);
        remove => _WeakEvent.Remove(value);
    }

    public event EventHandler ParamsWeakEvent
    {
        add => _ParamsWeakEvent.Add(value);
        remove => _ParamsWeakEvent.Remove(value);
    }

    public event Action? NoParamsEvent;

    public event Action<object>? OneParamsEvent;

    public event Action<object, string>? TwoParamsEvent;

    public event Action<object, string, int>? ThreeParamsEvent;

    public void RaiseEvent()
    {
        Event?.Invoke(this, EventArgs.Empty);
    }

    public void RaiseWeakEvent()
    {
        _WeakEvent.Invoke(this, EventArgs.Empty);
    }

    public void RaiseParamsWeakEvent()
    {
        _ParamsWeakEvent.Invoke(this, EventArgs.Empty);
    }
}
