using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

[MemoryDiagnoser]
public class Benchmark
{
    private SingletonService? _service;
    private IHost? _host;

    private readonly List<TransientSubscriber> _subscribers = new();

    [Params(1, 100, 1_000)]
    public int Invocations;

    [Params(1, 10, 100)]
    public int Subscribers;

    [GlobalSetup]
    public void Setup()
    {
        _host = HostConfiguration.CreateHost();
        _service = _host.Services.GetRequiredService<SingletonService>();
        _subscribers.AddRange(Enumerable.Range(0, Subscribers).Select(_ => _host.Services.GetRequiredService<TransientSubscriber>()));
        _subscribers.ForEach(s => s.Subscribe());
    }

    [GlobalCleanup]
    public void CleanUp()
    {
        _host?.Dispose();
    }

    [Benchmark]
    public void ThomasLevesque_WeakEvent() => _service?.Invoke_ThomasLevesque_WeakEvent(Invocations);

    [Benchmark]
    public void IncaTechnologies_ParamsWeakEvent() => _service?.Invoke_IncaTechnologies_ParamsWeakEvent(Invocations);

    [Benchmark]
    public void IncaTechnologies_WeakEvent() => _service?.Invoke_IncaTechnologies_WeakEvent(Invocations);

    [Benchmark]
    public void IncaTechnologies_WeakSubcriberHandler() => _service?.Invoke_IncaTechnologies_WeakSubcriberHandler(Invocations);

    [Benchmark]
    public void CLR_Event() => _service?.Invoke_CLR_Event(Invocations);

}




