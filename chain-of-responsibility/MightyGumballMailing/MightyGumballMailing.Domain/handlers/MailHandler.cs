using MightyGumballMailing.Domain.Entities;

namespace MightyGumballMailing.Domain.Handlers;

public interface MailHandler
{
  void HandleIncomingEmail(Email email);
}