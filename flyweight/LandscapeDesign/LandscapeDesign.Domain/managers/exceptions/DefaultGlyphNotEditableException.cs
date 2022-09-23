public class DefaultGlyphNotEditableException : Exception
{
  public DefaultGlyphNotEditableException(int x, int y)
    : base(message: $"The Glyph at ({x}, {y}) is a placeholder glyph and is not editable") { }
}