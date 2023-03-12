namespace IteratorTest
{
    public class ReplaceTests
    {
        [Fact]
        public void Test()
        {
            var profiles = new Profile[]
            {
                new() { Id = 1, Type = "Friends" }, new() { Id = 2, Type = "Workers" },
                new() { Id = 3, Type = "Workers" }, new() { Id = 4, Type = "Friends" },
                new() { Id = 5, Type = "Workers" }, new() { Id = 6, Type = "Friends" },
                new() { Id = 7, Type = "Friends" }
            };

            var weChat = new WeChat(profiles);

            var fa = new List<int>();
            var wa = new List<int>();

            foreach (var profile in weChat.GetFriends())
            {
                fa.Add(profile.Id);
            }

            foreach (var profile in weChat.GetWorkers())
            {
                wa.Add(profile.Id);
            }

            fa[0].ShouldBe(1);
            fa[1].ShouldBe(4);
            fa[2].ShouldBe(6);
            fa[3].ShouldBe(7);

            wa[0].ShouldBe(2);
            wa[1].ShouldBe(3);
            wa[2].ShouldBe(5);
        }
    }
}
