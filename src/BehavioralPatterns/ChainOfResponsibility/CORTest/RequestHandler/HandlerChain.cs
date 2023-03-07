namespace CORTest;

internal class HandlerChain
{
    private readonly List<Func<RequestHandler, RequestHandler>> _handlers = new();

    public void AddHandler(IHandler handler)
    {
        //version 2
        RequestHandler Func(RequestHandler next)
        {
            return context => handler.Handle(context, next);
        }

        //version 1
        //Func<RequestHandler, RequestHandler> func = next =>
        //{
        //    return context => handler.Handle(context, next);
        //};
        //本地函数更优，但是此处 1 & 2 没有区别

        _handlers.Add(Func);
    }

    public RequestHandler Build(RequestHandler requestAction)
    {
        RequestHandler last = requestAction;

        for (var i = _handlers.Count - 1; i >= 0; i--)
        {
            last = _handlers[i](last);
        }

        return last;
    }
}
