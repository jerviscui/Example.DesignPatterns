namespace DecoratorTest;

public class CompressionDataSource : DataSourceDecorator
{
    /// <inheritdoc />
    public CompressionDataSource(FileDataSource fileDataSource) : base(fileDataSource)
    {
    }

    private const string Signature = "__Compression";

    /// <inheritdoc />
    public override void Write(string data)
    {
        var msg = data + Signature;

        base.Write(msg);
    }

    /// <inheritdoc />
    public override string Read()
    {
        var msg = base.Read();

        return msg.Substring(0, msg.Length - Signature.Length);
    }
}
