
namespace DemoMoqLibrary
{

    public interface ISmtpSender
    {
        bool Send(string data);
    }

    public class SmtpSender: ISmtpSender
    {
        public SmtpSender()
        {
        }

        bool ISmtpSender.Send(string data)
        {
            return true;
        }
    }
}