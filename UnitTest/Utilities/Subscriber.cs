namespace UnitTest.Utilities;

public class Subscriber
{
    public int EventCount { get; set; }

    public int SecondEventCount { get; set; }

    public static int StaticEventCount { get; set; }

    public static int SecondStaticEventCount { get; set; }

    public void EventHandler(object? sender, EventArgs e)
    {
        EventCount++;
    }

    public void SecondEventHandler(object? sender, EventArgs e)
    {
        SecondEventCount++;
    }

    public static void StaticEventHandler(object? sender, EventArgs e)
    {
        StaticEventCount++;
    }

    public static void SecondStaticEventHandler(object? sender, EventArgs e)
    {
        SecondStaticEventCount++;
    }

    public static void ResetStaticCounters()
    {
        StaticEventCount = 0;
        SecondStaticEventCount = 0;
    }

    public void HandlerNoParams()
    {
        
    }

    public void HandlerOneParams(object arg1)
    {

    }

    public void HandlerTwoParams(object arg1, string arg2)
    {

    }

    public void HandlerThreeParams(object arg1, string arg2, int arg3)
    {

    }
}