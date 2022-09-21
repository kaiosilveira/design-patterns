using MightyGumballMailing.Domain.Entities;
using MightyGumballMailing.Domain.Enumerators;
using MightyGumballMailing.Domain.Services;

namespace MightyGumballMailing.Domain.Handlers;

public class SpamMailHandler : MailHandler
{
  private readonly MailService mailService;
  private readonly MailHandler successor;

  public SpamMailHandler(MailService mailService, MailHandler successor)
  {
    this.mailService = mailService;
    this.successor = successor;
  }

  public void HandleIncomingEmail(Email email)
  {
    if (email.Type == EmailType.SPAM)
    {
      this.mailService.MoveToJunk(email.Id);
    }
    else
    {
      this.successor.HandleIncomingEmail(email);
    }
  }
}