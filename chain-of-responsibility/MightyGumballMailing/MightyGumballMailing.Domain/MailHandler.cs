namespace MightyGumballMailing.Domain;

public interface MailHandler
{
  void HandleIncomingEmail(Email email);
}