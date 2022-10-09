using System.Text;

namespace DecoratorTest;

public class FileDataSource : IDataSource
{
    private readonly StringBuilder _data = new();

    /// <inheritdoc />
    public virtual void Write(string data) => _data.Append(data);

    /// <inheritdoc />
    public virtual string Read() => _data.ToString();
}
