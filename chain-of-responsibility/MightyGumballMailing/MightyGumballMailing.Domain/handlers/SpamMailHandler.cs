namespace MightyGumballMailing.Domain;

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