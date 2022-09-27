# TicTacToe

This is a simple tic-tac-toe game implemented to run in the terminal.

**Instructions:**

- Type `pn` to add your move, where `n` is within the range $0 \leq n < 9$
- Type `q!` to quit

## The Memento Pattern applied

Whenever an user plays a move, the `Game` object first asks the board for its current state, stores it, and then proceed to asking the board to actually compute the play. The When asked for its state, the `Board` object returns a `BoardState` object, containing all the relevant information regarding the state of the board in that moment of time. Then, if the uses requests for an undo, the game can easily gives the state back to the `Board` by calling `board.SetState(lastRecordedState)`, where `lastRecordedState` is the state of the last play computed by the `Game`.
