using MightyGumballMailing.Domain.Entities;
using MightyGumballMailing.Domain.Enumerators;
using MightyGumballMailing.Domain.Services;

namespace MightyGumballMailing.Domain.Handlers;

public class ComplaintMailHandler : MailHandler
{
  private readonly MailService mailService;
  private readonly MailHandler? successor;

  public ComplaintMailHandler(MailService mailService, MailHandler? successor)
  {
    this.mailService = mailService;
    this.successor = successor;
  }

  public void HandleIncomingEmail(Email email)
  {
    if (email.Type == EmailType.COMPLAINT)
    {
      this.mailService.ForwardToLegalDepartment(email);
    }
    else
    {
      this.successor?.HandleIncomingEmail(email);
    }
  }
}