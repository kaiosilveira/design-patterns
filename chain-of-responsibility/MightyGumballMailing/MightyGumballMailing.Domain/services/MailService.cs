using MightyGumballMailing.Domain.Entities;

namespace MightyGumballMailing.Domain.Services;

public interface MailService
{
  void ForwardToLegalDepartment(Email email);
  void MoveToJunk(string emailId);
}