using MightyGumballMailing.Domain.Entities;
using MightyGumballMailing.Domain.Enumerators;
using MightyGumballMailing.Domain.Handlers;
using MightyGumballMailing.Domain.Services.Fakes;

public class Program
{
  public static void Main(string[] args)
  {
    var emails = new List<Email>()
    {
      new Email(
        id: "abcd-1234",
        type: EmailType.UNKNOWN,
        subject: "Candidate application - Sr Software Engineer",
        body: "Hello, I would like to apply to the senior software engineer role"
      ),
      new Email(
        id: "abcd-1234",
        type: EmailType.COMPLAINT,
        subject: "Platform not working",
        body: "Hello, this morning I tried to use the web platform and it wasn't loading"
      ),
      new Email(
        id: "abcd-1234",
        type: EmailType.FAN,
        subject: "Best platform ever!",
        body: "Hello, I've been using your product for a while and I think it's really amazing!"
      ),
      new Email(
        id: "abcd-1234",
        type: EmailType.SPAM,
        subject: "You've just won the lottery",
        body: "Congrats on winning the lottery, Mr. Lucky!"
      )
    };

    var mailService = new FakeMailService();
    var defaultMailHandler = new DefaultMailHandler(mailService);
    var complaintMailHandler = new ComplaintMailHandler(mailService, successor: defaultMailHandler);
    var fanMailHandler = new FanMailHandler(mailService, successor: complaintMailHandler);
    var spamMailHandler = new SpamMailHandler(mailService, successor: fanMailHandler);

    emails.ForEach(email => spamMailHandler.HandleIncomingEmail(email));
  }
}