using TicTacToe.Domain;

public class Program
{
  public static void Main(string[] args)
  {
    var game = new Game(board: new InMemoryBoard());
    var input = "";
    while (input != "q!")
    {
      if (input?.Length == 2 && input[0] == 'p')
      {
        var position = Convert.ToInt32(input?[1].ToString());
        game.ComputePlay(playedPosition: position);
      }

      if (input?.ToLower() == "u") game.Undo();

      game.Draw();
      input = Console.ReadLine();
    }
  }
}