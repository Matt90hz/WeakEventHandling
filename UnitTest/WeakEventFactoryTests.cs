using FluentAssertions;
using IncaTechnologies.WeakEventHandling;
using IncaTechnologies.WeakEventHandling.Interfaces;

namespace UnitTest;

public sealed class WeakEventFactoryTests
{
    [Fact]
    public void Create_WeakEventNoParams_ShouldReturnWeakEvent()
    {
        // Arrange
        var weakEvent = WeakEventFactory.CreateWeakEvent<Action>();

        // Act
        var weakEventType = weakEvent.GetType();

        // Assert
        weakEventType.Should().BeAssignableTo<IWeakEvent<Action>>();
    }

    [Fact]
    public void Create_WeakEventWithOneParam_ShouldReturnWeakEvent()
    {
        // Arrange
        var weakEvent = WeakEventFactory.CreateWeakEvent<Action<object>>();

        // Act
        var weakEventType = weakEvent.GetType();

        // Assert
        weakEventType.Should().BeAssignableTo<IWeakEvent<Action<object>>>();
    }

    [Fact]
    public void Create_WeakEventWithTwoParam_ShouldReturnWeakEvent()
    {
        // Arrange
        var weakEvent = WeakEventFactory.CreateWeakEvent<Action<object, object>>();

        // Act
        var weakEventType = weakEvent.GetType();

        // Assert
        weakEventType.Should().BeAssignableTo<IWeakEvent<Action<object, object>>>();
    }

    [Fact]
    public void Create_WeakEventWithThreeParam_ShouldReturnWeakEvent()
    {
        // Arrange
        var weakEvent = WeakEventFactory.CreateWeakEvent<Action<object, object, object>>();

        // Act
        var weakEventType = weakEvent.GetType();

        // Assert
        weakEventType.Should().BeAssignableTo<IWeakEvent<Action<object, object, object>>>();
    }

    [Fact]
    public void Create_ParamsWeakEventNoParams_ShouldReturnWeakEvent()
    {
        // Arrange
        var weakEvent = WeakEventFactory.CreateParamsWeakEvent<Action>();

        // Act
        var weakEventType = weakEvent.GetType();

        // Assert
        weakEventType.Should().BeAssignableTo<IParamsWeakEvent<Action>>();
    }

    [Fact]
    public void Create_ParamsWeakEventWithOneParam_ShouldReturnWeakEvent()
    {
        // Arrange
        var weakEvent = WeakEventFactory.CreateParamsWeakEvent<Action<object>>();

        // Act
        var weakEventType = weakEvent.GetType();

        // Assert
        weakEventType.Should().BeAssignableTo<IParamsWeakEvent<Action<object>>>();
    }

    [Fact]
    public void Create_ParamsWeakEventWithTwoParam_ShouldReturnWeakEvent()
    {
        // Arrange
        var weakEvent = WeakEventFactory.CreateParamsWeakEvent<Action<object, string>>();

        // Act
        var weakEventType = weakEvent.GetType();

        // Assert
        weakEventType.Should().BeAssignableTo<IParamsWeakEvent<Action<object, string>>>();
    }

    [Fact]
    public void Create_ParamsWeakEventWithThreeParam_ShouldReturnWeakEvent()
    {
        // Arrange
        var weakEvent = WeakEventFactory.CreateParamsWeakEvent<Action<object, string, int>>();

        // Act
        var weakEventType = weakEvent.GetType();

        // Assert
        weakEventType.Should().BeAssignableTo<IParamsWeakEvent<Action<object, string, int>>>();
    }
}
