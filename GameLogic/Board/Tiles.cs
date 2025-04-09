

namespace GameLogic.Board.Models
{
    public record Piece 
    {
        public int Id { get; init; } 
        public string Name { get; init; } = string.Empty;
    }

    public record Tile
    {
        public int Id { get; init; }        // Unique identifier for debugging/tracking
        public int BoardX { get; init; }    // Logical board coordinate (grid based)
        public int BoardY { get; init; }
        public int ScreenX { get; init; }   // Screen coordinate for rendering
        public int ScreenY { get; init; }
        public string TileType { get; init; } = "path";     // special rules applies to different types 
        public List<Piece> Pieces { get; init; } = new();   // list of pieces on this tile
        public Tile? Next {  get; init; }   // nullable; repessents the next tile if applicable
    }
}
