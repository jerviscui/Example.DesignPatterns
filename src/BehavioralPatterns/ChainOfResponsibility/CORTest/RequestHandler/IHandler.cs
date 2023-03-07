namespace CORTest;

internal interface IHandler
{
    public Task Handle(RequestContext context, RequestHandler next);
}
