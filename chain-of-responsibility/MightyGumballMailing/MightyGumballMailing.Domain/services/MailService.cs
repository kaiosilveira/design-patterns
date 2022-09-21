using MightyGumballMailing.Domain.Entities;

namespace MightyGumballMailing.Domain.Services;

public interface MailService
{
  void ForwardToCEO(Email email);
  void ForwardToLegalDepartment(Email email);
  void MoveToJunk(string emailId);
}