namespace MightyGumballMailing.Domain.Repositories;

public interface MailRepository
{
  void MoveToJunk(string emailId);
}