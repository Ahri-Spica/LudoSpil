

namespace GameLogic.Board.Models
{
    public enum PlayerColour
    {
        Red,
        Green,
        Yellow,
        Blue, 
    }

    public record Piece 
    {
        public int Id { get; init; } 
        public PlayerColour Owner { get; init; }
        //public string Name { get; init; } = string.Empty;
    }

    public enum TileType
    {
        Path,   //
        Start,
        HomeEntry,
        HomePath,
        Home,
        Finish,
    }

    public enum TileKey
    {
        Default,
        Red,
        Green,
        Yellow,
        Blue,
    }

    public record Tile
    {
        public int Id               { get; init; }     // Unique identifier for debugging/tracking
        public int BoardX           { get; init; } // Logical board coordinate (grid based)
        public int BoardY           { get; init; }
        public TileType Type        { get; init; } = TileType.Path;  // special rules applies to different types 
        public PlayerColour? owner  { get; init; }
        public Dictionary<TileKey, int> Next { get; init; } = new(); // nullable; repessents the next tile 
        public List<Piece> Pieces   { get; init; } = new();  // list of pieces on this tile NOTE: not thread safe
    }
}
