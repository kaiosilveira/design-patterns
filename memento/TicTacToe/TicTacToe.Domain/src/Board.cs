using TicTacToe.Domain;

public interface Board
{
  void AddPlay(int position, string symbol);

  BoardState GetState();

  void SetState(BoardState state);
}