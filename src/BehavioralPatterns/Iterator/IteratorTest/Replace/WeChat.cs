namespace IteratorTest;

public class WeChat
{
    private readonly IProfileIterator _friendsIterator;

    private readonly IProfileIterator _workersIterator;

    private readonly Profile[] _profiles;

    public WeChat(Profile[] profiles)
    {
        _profiles = profiles;

        _friendsIterator = new FriendsIterator(_profiles);
        _workersIterator = new WorkersIterator(_profiles);
    }

    public IEnumerable<Profile> GetFriends()
    {
        return GetProfile(_friendsIterator);
    }

    public IEnumerable<Profile> GetWorkers()
    {
        return GetProfile(_workersIterator);
    }

    private static IEnumerable<Profile> GetProfile(IProfileIterator iterator)
    {
        while (iterator.HasNext())
        {
            yield return iterator.GetNext();
        }
    }
}
