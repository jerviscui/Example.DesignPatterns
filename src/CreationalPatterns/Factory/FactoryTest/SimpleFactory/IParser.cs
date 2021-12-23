namespace FactoryTest;

public interface IParser
{
    /// <summary>
    /// Parses the specified input.
    /// </summary>
    /// <param name="input">The input.</param>
    public string Parse(string input);
}
