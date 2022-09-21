using Xunit;
using Moq;

namespace MightyGumballMailing.DomainTests;

public enum EmailType
{
  UNKNOWN = 0,
  SPAM = 1,
  FAN = 2,
  COMPLAINT = 3,
}

public interface MailRepository
{
  void MoveToJunk(string emailId);
}

public class Email
{
  public string Id { get; private set; }
  public EmailType Type { get; private set; }

  public Email(string id, EmailType type, string subject, string body)
  {
    this.Id = id;
    this.Type = type;
  }
}

public interface MailHandler
{
  void HandleIncomingEmail(Email email);
}

public class SpamMailHandler : MailHandler
{
  private readonly MailRepository mailRepository;
  private readonly MailHandler successor;

  public SpamMailHandler(MailRepository mailRepository, MailHandler successor)
  {
    this.mailRepository = mailRepository;
    this.successor = successor;
  }

  public void HandleIncomingEmail(Email email)
  {
    if (email.Type == EmailType.SPAM)
    {
      this.mailRepository.MoveToJunk(email.Id);
    }
    else
    {
      this.successor.HandleIncomingEmail(email);
    }
  }
}

public class SpamMailHandlerTest
{
  [Fact]
  public void TestHandlesSpamEmail()
  {
    var mockedMailRepo = new Mock<MailRepository>();
    var mockedSuccessorMailHandler = new Mock<MailHandler>();
    var email = new Email(
      id: "abcd-1234",
      type: EmailType.SPAM,
      subject: "You've just won the lottery",
      body: "Congrats on winning the lottery, Mr. Lucky!"
    );

    var handler = new SpamMailHandler(
      mailRepository: mockedMailRepo.Object,
      successor: mockedSuccessorMailHandler.Object
    );

    handler.HandleIncomingEmail(email);

    mockedMailRepo.Verify(instance => instance.MoveToJunk(email.Id), Times.Once());
  }

  [Fact]
  public void TestDelegatesHandlingToSuccessorIfMailTypeIsNotSpam()
  {
    var mockedMailRepo = new Mock<MailRepository>();
    var mockedSuccessorMailHandler = new Mock<MailHandler>();
    var email = new Email(
      id: "abcd-1234",
      type: EmailType.UNKNOWN,
      subject: "Candidate application - Sr Software Engineer",
      body: "Hello, I would like to apply to the senior software engineer role"
    );

    var handler = new SpamMailHandler(
      mailRepository: mockedMailRepo.Object,
      successor: mockedSuccessorMailHandler.Object
    );

    handler.HandleIncomingEmail(email);

    mockedSuccessorMailHandler.Verify(instance => instance.HandleIncomingEmail(email), Times.Once());
  }
}