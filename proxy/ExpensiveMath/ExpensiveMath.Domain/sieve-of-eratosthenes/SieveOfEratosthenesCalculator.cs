namespace ExpensiveMath.Algorithms;

public class SieveOfEratosthenesCalculator : SieveOfEratosthenes
{
  protected List<int> GetPrimesUpTo(int limit)
  {
    var list = new List<int>();
    var crossedOutItems = new List<int>();
    for (int i = 2; i <= limit; i++)
    {
      list.Add(i);
    }

    list.ForEach(n =>
    {
      var result = n;
      var currentPosition = 0;
      while (result < limit && !crossedOutItems.Contains(n))
      {
        result = n * list[currentPosition];
        crossedOutItems.Add(result);
        currentPosition++;
      }
    });

    return list.Where(i => !crossedOutItems.Contains(i)).ToList();
  }

  public void PrintPrimeCountUpTo(int n)
  {
    var result = this.GetPrimesUpTo(n);
    Console.WriteLine($"Result {result.Count.ToString()}");
  }
}
