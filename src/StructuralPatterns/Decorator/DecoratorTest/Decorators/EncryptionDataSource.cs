namespace DecoratorTest;

public class EncryptionDataSource : DataSourceDecorator
{
    /// <inheritdoc />
    public EncryptionDataSource(FileDataSource fileDataSource) : base(fileDataSource)
    {
    }

    private const string Salt = "Encryption__";

    /// <inheritdoc />
    public override void Write(string data)
    {
        var msg = Salt + data;

        base.Write(msg);
    }

    /// <inheritdoc />
    public override string Read()
    {
        var msg = base.Read();

        return msg.Substring(Salt.Length);
    }
}
