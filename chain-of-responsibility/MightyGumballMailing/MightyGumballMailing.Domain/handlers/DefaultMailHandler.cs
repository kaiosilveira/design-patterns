using MightyGumballMailing.Domain.Entities;
using MightyGumballMailing.Domain.Enumerators;
using MightyGumballMailing.Domain.Services;

namespace MightyGumballMailing.Domain.Handlers;

public class DefaultMailHandler : MailHandler
{
  private readonly MailService mailService;

  public DefaultMailHandler(MailService mailService)
  {
    this.mailService = mailService;
  }

  public void HandleIncomingEmail(Email email)
  {
    if (email.Type == EmailType.UNKNOWN)
    {
      this.mailService.MoveToInbox(email);
    }
  }
}