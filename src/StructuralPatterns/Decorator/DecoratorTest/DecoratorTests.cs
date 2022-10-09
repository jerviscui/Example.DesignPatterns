namespace DecoratorTest
{
    public class DecoratorTests
    {
        [Fact]
        public void FileDataSource_Test()
        {
            var dataSource = new FileDataSource();

            var s = "aaa";
            dataSource.Write(s);

            dataSource.Read().ShouldBe(s);
        }

        [Fact]
        public void EncryptionDataSource_Test()
        {
            var dataSource = new FileDataSource();
            dataSource = new EncryptionDataSource(dataSource);

            var s = "aaa";
            dataSource.Write(s);

            dataSource.Read().ShouldBe(s);
        }

        [Fact]
        public void CompressionDataSource_Test()
        {
            var dataSource = new FileDataSource();
            dataSource = new CompressionDataSource(dataSource);

            var s = "aaa";
            dataSource.Write(s);

            dataSource.Read().ShouldBe(s);
        }

        [Fact]
        public void MultiDecorators_Test()
        {
            var dataSource = new FileDataSource();
            dataSource = new EncryptionDataSource(dataSource);
            dataSource = new CompressionDataSource(dataSource);

            var s = "aaa";
            dataSource.Write(s);

            dataSource.Read().ShouldBe(s);
        }
    }
}
