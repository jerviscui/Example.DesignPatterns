namespace IteratorTest
{
    public class SimpleTests
    {
        [Fact]
        public void Test()
        {
            var collection = new SimpleCollection { 1, 10, 100 };
            var list = new List<int>();
            foreach (var i in collection)
            {
                list.Add(i);
            }

            list[0].ShouldBe(1);
            list[1].ShouldBe(10);
            list[2].ShouldBe(100);

            //using var enumerator = collection.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    //enumerator.Current;
            //}
        }
    }
}
