namespace ChessLib.Utils;

public static class ThrowHelper
{
    public class NotationParsingException : Exception
    {
        public NotationParsingException () {}
        public NotationParsingException (string message) : base(message) {}
        public NotationParsingException (string message, Exception innerException) : base (message, innerException) {}  
    }
}