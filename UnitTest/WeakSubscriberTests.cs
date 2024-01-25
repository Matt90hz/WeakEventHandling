using FluentAssertions;
using IncaTechnologies.WeakEventHandling;
using UnitTest.Utilities;

namespace UnitTest;

public sealed class WeakSubscriberTests
{
    [Fact]
    public void Add_MultipleWeakSubscribers_AllShouldBeInvoked()
    {
        // Arrange
        Publisher publisher = new();
        Subscriber subscriber1 = new();
        Subscriber subscriber2 = new();

        var weakSubscriber1 = WeakSubscriberFactory.Create<EventHandler>(subscriber1.EventHandler);
        var weakSubscriber2 = WeakSubscriberFactory.Create<EventHandler>(subscriber1.SecondEventHandler);
        var weakSubscriber3 = WeakSubscriberFactory.Create<EventHandler>(subscriber2.EventHandler);
        var weakSubscriber4 = WeakSubscriberFactory.Create<EventHandler>(subscriber2.SecondEventHandler);

        // Act
        publisher.Event += weakSubscriber1.WeakHandler;
        publisher.Event += weakSubscriber2.WeakHandler;
        publisher.Event += weakSubscriber3.WeakHandler;
        publisher.Event += weakSubscriber4.WeakHandler;

        publisher.RaiseEvent();

        // Assert
        subscriber1.EventCount.Should().Be(1, "because it's subcribed and the event has been raised");
        subscriber1.SecondEventCount.Should().Be(1, "because it's subcribed and the event has been raised");
        subscriber2.EventCount.Should().Be(1, "because it's subcribed and the event has been raised");
        subscriber2.SecondEventCount.Should().Be(1, "because it's subcribed and the event has been raised");
    }

    [Fact]
    public void Remove_SingleWeakHandler_HandlerShouldNotBeInvoked()
    {
        // Arrange
        Publisher publisher = new();
        Subscriber subscriber1 = new();
        Subscriber subscriber2 = new();

        var weakSubscriber1 = WeakSubscriberFactory.Create<EventHandler>(subscriber1.EventHandler);
        var weakSubscriber2 = WeakSubscriberFactory.Create<EventHandler>(subscriber1.SecondEventHandler);
        var weakSubscriber3 = WeakSubscriberFactory.Create<EventHandler>(subscriber2.EventHandler);
        var weakSubscriber4 = WeakSubscriberFactory.Create<EventHandler>(subscriber2.SecondEventHandler);
       
        publisher.Event += weakSubscriber1.WeakHandler;
        publisher.Event += weakSubscriber2.WeakHandler;
        publisher.Event += weakSubscriber4.WeakHandler;
        publisher.Event += weakSubscriber3.WeakHandler;
        
        // Act
        publisher.RaiseEvent();
        publisher.Event -= weakSubscriber3.WeakHandler;
        publisher.RaiseEvent();

        // Assert
        subscriber1.EventCount.Should().Be(2, "because the handler has not been removed after the event has been re-raised");
        subscriber1.SecondEventCount.Should().Be(2, "because the handler has not been removed after the event has been re-raised");
        subscriber2.EventCount.Should().Be(1, "because after the handler is removed it shoudn't be rasied again");
        subscriber2.SecondEventCount.Should().Be(2, "because the handler has not been removed after the event has been re-raised");
    }

    [Fact]
    public void LeakPrevention_WeakSubscriberToEvent_ShouldBeCollected()
    {
        // Arrange
        static WeakReference<Subscriber> Subscribe(Publisher publisher)
        {
            Subscriber subscriber = new();

            var weakSubscriber = WeakSubscriberFactory.Create<EventHandler>(subscriber.EventHandler);
            publisher.WeakEvent += weakSubscriber.WeakHandler;

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

}
