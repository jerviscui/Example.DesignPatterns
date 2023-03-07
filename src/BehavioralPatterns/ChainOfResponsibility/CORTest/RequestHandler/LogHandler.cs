namespace CORTest;

internal class LogHandler : IHandler
{
    /// <inheritdoc />
    public async Task Handle(RequestContext context, RequestHandler next)
    {
        // Do something
        //before

        await next(context);

        //after
    }
}
