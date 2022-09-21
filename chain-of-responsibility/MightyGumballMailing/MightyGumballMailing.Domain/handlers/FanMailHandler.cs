using MightyGumballMailing.Domain.Entities;
using MightyGumballMailing.Domain.Enumerators;
using MightyGumballMailing.Domain.Services;

namespace MightyGumballMailing.Domain.Handlers;

public class FanMailHandler : MailHandler
{
  private readonly MailService mailService;
  private readonly MailHandler? successor;

  public FanMailHandler(MailService mailService, MailHandler? successor)
  {
    this.mailService = mailService;
    this.successor = successor;
  }

  public void HandleIncomingEmail(Email email)
  {
    if (email.Type == EmailType.FAN)
    {
      this.mailService.ForwardToCEO(email);
    }
    else
    {
      this.successor?.HandleIncomingEmail(email);
    }
  }
}