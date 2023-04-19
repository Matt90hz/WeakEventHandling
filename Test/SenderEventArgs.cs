
public class SenderEventArgs : EventArgs
{
    public string Sender { get; }

    public SenderEventArgs(string sender)
    {
        Sender = sender;
    }
}




