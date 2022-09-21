using MightyGumballMailing.Domain.Enumerators;

namespace MightyGumballMailing.Domain.Entities;

public class Email
{
  public string Id { get; private set; }
  public EmailType Type { get; private set; }

  public Email(string id, EmailType type, string subject, string body)
  {
    this.Id = id;
    this.Type = type;
  }
}