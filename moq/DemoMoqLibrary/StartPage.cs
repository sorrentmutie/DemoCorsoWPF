namespace DemoMoqLibrary;

public class StartPage
{
    private readonly ISmtpSender sender;

    public virtual string? Name { get; set; }

    public StartPage(ISmtpSender sender)
    {
        this.sender = sender;
    }


    public virtual string DoSomething(string argument)
    {
        return $"{argument}, {Name}";
    }

    public bool MyMethod()
    {
        sender.Send("message");
        return true;
    }

}