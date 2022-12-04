namespace ObserverTest;

public class EventData
{
    public object? Sender { get; set; }

    //public static EventData<TData> Create<TData>(TData data)
    //{
    //    return data;
    //}
}

//public class EventData<TData>
//{
//    public TData Data { get; set; }

//    private EventData(TData data)
//    {
//        Data = data;
//    }

//    public static implicit operator EventData<TData>(TData data)
//    {
//        return new EventData<TData>(data);
//    }
//}
