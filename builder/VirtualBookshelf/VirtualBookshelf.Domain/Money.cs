
namespace VirtualBookshelf.Domain.ValueObjects;

public class Money
{
  public int AmountInCents { get; }

  public string Currency { get; }

  public Money(int amountInCents, string currency)
  {
    this.AmountInCents = amountInCents;
    this.Currency = currency;
  }
}
