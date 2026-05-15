namespace ChessLib.Utils;

public static class ThrowHelper
{
    /// <summary>
    /// Failed to parse external string-based notation (like FEN or algebraic notation)
    /// </summary>
    public class NotationParsingException : ChessException
    {
        public NotationParsingException () {}
        public NotationParsingException (string message) : base(message) {}
        public NotationParsingException (string message, Exception innerException) : base (message, innerException) {}  
    }
    
    /// <summary>
    /// Failed to select piece
    /// </summary>
    public class PieceAmbiguityException : ChessException
    {
        public PieceAmbiguityException () {}
        public PieceAmbiguityException (string message) : base(message) {}
        public PieceAmbiguityException (string message, Exception innerException) : base (message, innerException) {}  
    }
    
    /// <summary>
    /// The function is not meant to use the given type
    /// </summary>
    public class PieceTypeNotSupported : ChessException
    {
        public PieceTypeNotSupported () {}
        public PieceTypeNotSupported (string message) : base(message) {}
        public PieceTypeNotSupported (string message, Exception innerException) : base (message, innerException) {}  
    }
    
    /// <summary>
    /// Base class for all ChessLib exceptions
    /// </summary>
    public class ChessException : Exception
    {
        public ChessException () {}
        public ChessException (string message) : base(message) {}
        public ChessException (string message, Exception innerException) : base (message, innerException) {}  
    }
}