using IncaTechnologies.WeakEventHandling.Interfaces;
using IncaTechnologies.WeakEventHandling;
using FluentAssertions;
using UnitTest.Utilities;

namespace UnitTest;

public sealed class WeakSubscriberFactoryTests
{
    [Fact]
    public void Create_WeakSubscriberNoParams_ShouldReturnWeakSubscriber()
    {
        // Arrange
        Subscriber subscriber = new();
        var weakSubscriber = WeakSubscriberFactory.Create(subscriber.HandlerNoParams);

        // Act
        var weakSubscriberType = weakSubscriber.GetType();

        // Assert
        weakSubscriberType.Should().BeAssignableTo<IWeakSubscriber<Action>>();
    }

    [Fact]
    public void Create_WeakSubscriberWithOneParam_ShouldReturnWeakSubscriber()
    {
        // Arrange
        Subscriber subscriber = new();
        var weakSubscriber = WeakSubscriberFactory.Create(subscriber.HandlerOneParams);

        // Act
        var weakSubscriberType = weakSubscriber.GetType();

        // Assert
        weakSubscriberType.Should().BeAssignableTo<IWeakSubscriber<Action<object>>>();
    }

    [Fact]
    public void Create_WeakSubscriberWithTwoParam_ShouldReturnWeakSubscriber()
    {
        // Arrange
        Subscriber subscriber = new();
        var weakSubscriber = WeakSubscriberFactory.Create(subscriber.HandlerTwoParams);

        // Act
        var weakSubscriberType = weakSubscriber.GetType();

        // Assert
        weakSubscriberType.Should().BeAssignableTo<IWeakSubscriber<Action<object, string>>>();
    }

    [Fact]
    public void Create_WeakSubscriberWithThreeParam_ShouldReturnWeakSubscriber()
    {
        // Arrange
        Subscriber subscriber = new();
        var weakSubscriber = WeakSubscriberFactory.Create(subscriber.HandlerThreeParams);

        // Act
        var weakSubscriberType = weakSubscriber.GetType();

        // Assert
        weakSubscriberType.Should().BeAssignableTo<IWeakSubscriber<Action<object, string, int>>>();
    }
}