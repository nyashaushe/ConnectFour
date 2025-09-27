public class State
{
    public Player[] Players { get; set; }
    public int GameRoundsPlayed { get; set; }
    public bool GameOver { get; set; }
    public Piece[] Pieces { get; set; }
    public int TurnTimeLimit { get; set; } = 30; // Time limit in seconds for each turn
    public int CurrentPlayerTimeRemaining { get; set; }
    public int CurrentPlayerIndex { get; set; }
    public int BoardRows { get; } = 6;
    public int BoardCols { get; } = 7;

    public State()
    {
        Players = new Player[]
        {
            new Player() { Name = "Player", Points = 0 },
            new Player() { Name = "Opponent", Points = 0 }
        };
        GameRoundsPlayed = 0;
        GameOver = false;
        CurrentPlayerIndex = 0;
        CurrentPlayerTimeRemaining = TurnTimeLimit;
        Pieces = new Piece[BoardRows * BoardCols];
        for (int i = 0; i < Pieces.Length; i++)
        {
            Pieces[i] = new Piece();
        }
    }

    public void ResetGame()
    {
        GameOver = false;
        Players[0].Points = 0;
        Players[1].Points = 0;
        CurrentPlayerIndex = 0;
        CurrentPlayerTimeRemaining = TurnTimeLimit;
        for (int i = 0; i < Pieces.Length; i++)
        {
            Pieces[i] = new Piece();
        }
    }

    public void EndGame()
    {
        GameOver = true;
        GameRoundsPlayed++;
        // award winner logic here
    }

    public bool PlayPiece(int col, int playerIndex)
    {
        // Place piece in the lowest available row in the column
        for (int row = BoardRows - 1; row >= 0; row--)
        {
            int idx = row * BoardCols + col;
            if (!Pieces[idx].Occupied)
            {
                Pieces[idx].Occupied = true;
                Pieces[idx].PlayerIndex = playerIndex;
                return true;
            }
        }
        return false; // column full
    }
}

public class Player
{
    public string Name { get; set; }
    public int Points { get; set; }
}

public class Piece
{
    public bool Occupied { get; set; }
    public int? PlayerIndex { get; set; }
}
