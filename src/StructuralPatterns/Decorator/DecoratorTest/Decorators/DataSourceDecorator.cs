namespace DecoratorTest;

public abstract class DataSourceDecorator : FileDataSource
{
    protected readonly FileDataSource DataSource;

    protected DataSourceDecorator(FileDataSource fileDataSource)
    {
        DataSource = fileDataSource;
    }

    /// <inheritdoc />
    public override void Write(string data) => DataSource.Write(data);

    /// <inheritdoc />
    public override string Read() => DataSource.Read();
}
