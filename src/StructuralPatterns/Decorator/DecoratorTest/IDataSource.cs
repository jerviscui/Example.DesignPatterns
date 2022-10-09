namespace DecoratorTest;

public interface IDataSource
{
    /// <summary>
    /// Writes the specified data.
    /// </summary>
    /// <param name="data">The data.</param>
    public void Write(string data);

    /// <summary>
    /// Reads this instance.
    /// </summary>
    /// <returns></returns>
    public string Read();
}
