using Moq;

namespace StrategyTest
{
    public class FactoryTests
    {
        [Fact]
        public void QuickSortStrategy_Test()
        {
            var mock = new Mock<IFileSize>();
            mock.Setup(x => x.GetSize()).Returns(999);

            var sorter = new Sorter("", mock.Object);

            Should.Throw<NotImplementedException>(() => sorter.SortFile())
                .Message.ShouldBe(nameof(QuickSortStrategy));
        }

        [Fact]
        public void ExternalSortStrategy_Test()
        {
            var mock = new Mock<IFileSize>();
            mock.Setup(x => x.GetSize()).Returns(999_999);

            var sorter = new Sorter("", mock.Object);

            Should.Throw<NotImplementedException>(() => sorter.SortFile())
                .Message.ShouldBe(nameof(ExternalSortStrategy));
        }

        [Fact]
        public void ConcurrentSortStrategy_Test()
        {
            var mock = new Mock<IFileSize>();
            mock.Setup(x => x.GetSize()).Returns(999_999_999);

            var sorter = new Sorter("", mock.Object);

            Should.Throw<NotImplementedException>(() => sorter.SortFile())
                .Message.ShouldBe(nameof(ConcurrentSortStrategy));
        }

        [Fact]
        public void MapReduceSortStrategy_Test()
        {
            var mock = new Mock<IFileSize>();
            mock.Setup(x => x.GetSize()).Returns(999_999_999_999);

            var sorter = new Sorter("", mock.Object);

            Should.Throw<NotImplementedException>(() => sorter.SortFile())
                .Message.ShouldBe(nameof(MapReduceSortStrategy));
        }
    }
}
