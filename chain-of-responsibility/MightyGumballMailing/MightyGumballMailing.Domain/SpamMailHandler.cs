namespace MightyGumballMailing.Domain;

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