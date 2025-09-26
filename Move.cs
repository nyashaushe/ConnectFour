namespace ConnectFour;

public class Move
{
    public int Player { get; set; }
    public int Column { get; set; }
    public int Row { get; set; }
    public int TurnNumber { get; set; }

    public string Description => $"Turn {TurnNumber}: Player {Player} placed in column {Column + 1}, row {Row + 1}";
}