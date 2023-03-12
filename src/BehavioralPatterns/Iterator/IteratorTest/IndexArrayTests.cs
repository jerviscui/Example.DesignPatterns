namespace IteratorTest
{
    public class IndexArrayTests
    {
        [Fact]
        public void Add_Test()
        {
            var array = new IndexArray<int>(10);
            array.Add(0, 1);
            array.Add(1, 10);
            array.Add(2, 100);

            array.Get(0).ShouldBe(1);
            array.Get(1).ShouldBe(10);
            array.Get(2).ShouldBe(100);
        }

        [Fact]
        public void Add_OutOfRange_Test()
        {
            var array = new IndexArray<int>(10);
            array.Add(0, 1);
            array.Add(1, 1);
            array.Add(2, 1);

            Should.Throw<IndexOutOfRangeException>(() => array.Add(10, 1));
        }

        [Fact]
        public void Remove_Test()
        {
            var array = new IndexArray<int>(10);
            array.Add(0, 1);
            array.Add(1, 10);
            array.Add(2, 100);
            array.Remove(10);

            array.Get(0).ShouldBe(1);
            array.Get(1).ShouldBe(0);
            array.Get(2).ShouldBe(100);
        }

        [Fact]
        public void Foreach_Test()
        {
            var array = new IndexArray<int>(10);
            array.Add(0, 1);
            array.Add(1, 10);
            array.Add(2, 100);

            var list = new List<int>();
            foreach (var i in array)
            {
                list.Add(i);
            }

            list[0].ShouldBe(1);
            list[1].ShouldBe(10);
            list[2].ShouldBe(100);
        }

        [Fact]
        public void Foreach_AfterAdd_Test()
        {
            var array = new IndexArray<int>(10);
            array.Add(0, 1);
            array.Add(1, 10);

            using var enumerator = array.GetEnumerator();
            enumerator.MoveNext(); //0

            enumerator.MoveNext(); //1
            enumerator.Current.ShouldBe(10);

            array.Add(2, 100);

            enumerator.MoveNext().ShouldBeFalse(); //3
        }

        [Fact]
        public void Foreach_BeforeRemove_Test()
        {
            var array = new IndexArray<int>(10);
            array.Add(0, 1);
            array.Add(1, 10);
            array.Add(2, 100);
            array.Add(3, 1000);
            array.Remove(100);

            var list = new List<int>();
            foreach (var i in array)
            {
                list.Add(i);
            }

            list[0].ShouldBe(1);
            list[1].ShouldBe(10);
            list[2].ShouldBe(1000);

            for (var i = 0; i < list.Count; i++)
            {
                list.RemoveAt(0);
            }
        }

        [Fact]
        public void Foreach_AfterRemove_Test()
        {
            var array = new IndexArray<int>(10);
            array.Add(0, 1);
            array.Add(1, 10);
            array.Add(2, 100);
            array.Add(3, 1000);
            array.Remove(10);

            using var enumerator = array.GetEnumerator();
            enumerator.MoveNext(); //0

            enumerator.MoveNext(); //2
            enumerator.Current.ShouldBe(100);

            array.Remove(1000);
            enumerator.MoveNext().ShouldBeTrue(); //3
            enumerator.Current.ShouldBe(1000);
        }

#if RELEASE
        //"Must run with Release"
        [Fact]
        public void Clear_Test()
        {
            var array = new IndexArray<int>(10);
            array.Add(0, 1);
            array.Add(1, 10);
            array.Add(2, 100);
            array.Add(3, 1000);
            array.Remove(10);

            var iterator1 = array.GetEnumerator();

            array.Remove(1000);

            iterator1.Dispose();
            iterator1 = null;

            GC.Collect();

            array.Clear(); //will delete 10 and 1000
            array.Length.ShouldBe(2);
        }

        [Fact]
        public void Clear_DeleteNone_Test()
        {
            var array = new IndexArray<int>(10);
            array.Add(0, 1);
            array.Add(1, 10);
            array.Add(2, 100);
            array.Add(3, 1000);

            var iterator1 = array.GetEnumerator();

            array.Remove(10);

            var iterator2 = array.GetEnumerator();

            array.Remove(1000);

            iterator2.Dispose();
            iterator2 = null;

            GC.Collect();

            array.Clear(); //will delete none
            array.Length.ShouldBe(4);

            iterator1.Dispose();
        }
#endif
    }
}
