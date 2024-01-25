using FluentAssertions;
using UnitTest.Utilities;

namespace UnitTest;

public sealed class WeakEventTests
{
    [Fact]
    public void Add_MultipleHandlers_AllHandlersShouldBeInvoked()
    {
        // Arrange
        Publisher publisher = new();
        Subscriber subscriber1 = new();
        Subscriber subscriber2 = new();

        // Act
        Subscriber.ResetStaticCounters();
        publisher.WeakEvent += subscriber1.EventHandler;
        publisher.WeakEvent += subscriber1.SecondEventHandler;
        publisher.WeakEvent += subscriber2.EventHandler;
        publisher.WeakEvent += Subscriber.StaticEventHandler;
        publisher.WeakEvent += Subscriber.SecondStaticEventHandler;

        publisher.RaiseWeakEvent();

        // Assert
        subscriber1.EventCount.Should().Be(1, "because it's subcribed and the event has been raised");
        subscriber1.SecondEventCount.Should().Be(1, "because it's subcribed and the event has been raised");
        subscriber2.EventCount.Should().Be(1, "because it's subcribed and the event has been raised");
        Subscriber.StaticEventCount.Should().Be(1, "because it's subcribed and the event has been raised");
        Subscriber.SecondStaticEventCount.Should().Be(1, "because it's subcribed and the event has been raised");
    }

    [Fact]
    public void Remove_SingleHandler_HandlerShouldNotBeInvoked()
    {
        // Arrange
        Publisher publisher = new();
        Subscriber subscriber1 = new();
        Subscriber subscriber2 = new();

        publisher.WeakEvent += subscriber1.EventHandler;
        publisher.WeakEvent += subscriber2.SecondEventHandler;
        publisher.WeakEvent += subscriber1.SecondEventHandler;
        publisher.WeakEvent += subscriber2.EventHandler;
        publisher.RaiseWeakEvent();

        subscriber1.EventCount.Should().Be(1, "because it's rasied once");
        subscriber2.SecondEventCount.Should().Be(1, "because it's rasied once");
        subscriber1.SecondEventCount.Should().Be(1, "because it's rasied once");
        subscriber2.EventCount.Should().Be(1, "because it's rasied once");

        // Act
        publisher.WeakEvent -= subscriber1.SecondEventHandler;
        publisher.RaiseWeakEvent();

        // Assert
        subscriber1.EventCount.Should().Be(2, "because the handler has not been removed after the event has been re-raised");
        subscriber2.SecondEventCount.Should().Be(2, "because the handler has not been removed after the event has been re-raised");
        subscriber1.SecondEventCount.Should().Be(1, "because after the handler is removed it shoudn't be rasied again");
        subscriber2.EventCount.Should().Be(2, "because the handler has not been removed after the event has been re-raised");

    }

    [Fact]
    public void Remove_StaticHandler_HandlerShouldNotBeInvoked()
    {
        // Arrange
        Publisher publisher = new();
        Subscriber subscriber1 = new();
        Subscriber subscriber2 = new();

        Subscriber.ResetStaticCounters();
        publisher.WeakEvent += subscriber1.EventHandler;
        publisher.WeakEvent += subscriber1.SecondEventHandler;
        publisher.WeakEvent += Subscriber.StaticEventHandler;
        publisher.WeakEvent += Subscriber.SecondStaticEventHandler;
        publisher.WeakEvent += subscriber2.EventHandler;
        publisher.RaiseWeakEvent();

        subscriber1.EventCount.Should().Be(1, "because it's rasied once");
        subscriber1.SecondEventCount.Should().Be(1, "because it's rasied once");
        Subscriber.StaticEventCount.Should().Be(1, "because it's rasied once");
        Subscriber.SecondStaticEventCount.Should().Be(1, "because it's rasied once");
        subscriber2.EventCount.Should().Be(1, "because it's rasied once");

        // Act
        publisher.WeakEvent -= Subscriber.SecondStaticEventHandler;
        publisher.RaiseWeakEvent();

        // Assert
        subscriber1.EventCount.Should().Be(2, "because the handler has not been removed after the event has been re-raised");
        subscriber1.SecondEventCount.Should().Be(2, "because the handler has not been removed after the event has been re-raised");
        Subscriber.StaticEventCount.Should().Be(2, "because the handler has not been removed after the event has been re-raised");
        Subscriber.SecondStaticEventCount.Should().Be(1, "because after the handler is removed it shoudn't be rasied again");
        subscriber2.EventCount.Should().Be(2, "because the handler has not been removed after the event has been re-raised");
    }

    [Fact]
    public void LeakPrevention_SubscriberToWeakEvent_ShouldBeCollected()
    {
        // Arrange
        static WeakReference<Subscriber> Subscribe(Publisher publisher)
        {
            Subscriber subscriber = new();
            publisher.WeakEvent += subscriber.EventHandler;

            return new(subscriber);
        }

        Publisher publisher = new();
        WeakReference<Subscriber> weaksubscriber = Subscribe(publisher);

        // Act
        GC.Collect();
        GC.WaitForPendingFinalizers();

        // Assert
        weaksubscriber.TryGetTarget(out _).Should().BeFalse("because the subscriber is not referenced anymore");
    }

    [Fact]
    public void LeakPrevention_SubscriberToStandardEvent_ShouldNotBeCollected()
    {
        // Arrange
        static WeakReference<Subscriber> Subscribe(Publisher publisher)
        {
            Subscriber subscriber = new();
            publisher.Event += subscriber.EventHandler;

            return new(subscriber);
        }

        Publisher publisher = new();
        WeakReference<Subscriber> weaksubscriber = Subscribe(publisher);

        // Act
        GC.Collect();
        GC.WaitForPendingFinalizers();

        // Assert
        weaksubscriber.TryGetTarget(out _).Should().BeTrue("because the subscriber is still referenced by the publisher");
    }
}
