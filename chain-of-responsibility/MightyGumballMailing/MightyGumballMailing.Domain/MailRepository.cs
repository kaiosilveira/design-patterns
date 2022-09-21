namespace MightyGumballMailing.Domain;

public interface MailRepository
{
  void MoveToJunk(string emailId);
}