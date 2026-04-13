namespace ChessLib.Utils;

public static class ThrowHelper
{
    /// <summary>
    /// Failed to parse external string-based notation (like FEN or algebraic notation)
    /// </summary>
    public class NotationParsingException : Exception
    {
        public NotationParsingException () {}
        public NotationParsingException (string message) : base(message) {}
        public NotationParsingException (string message, Exception innerException) : base (message, innerException) {}  
    }
}