using MightyGumballMailing.Domain.Entities;

namespace MightyGumballMailing.Domain.Services.Fakes;

public class FakeMailService : MailService
{
  public void ForwardToCEO(Email email)
  {
    Console.WriteLine($"Forwarding {email.Id} to the CEO...");
  }

  public void ForwardToLegalDepartment(Email email)
  {
    Console.WriteLine($"Forwarding {email.Id} to the Legal Department...");
  }

  public void MoveToInbox(Email email)
  {
    Console.WriteLine($"Moving {email.Id} to inbox...");
  }

  public void MoveToJunk(string emailId)
  {
    Console.WriteLine($"Marking {emailId} as Junk...");
  }
}