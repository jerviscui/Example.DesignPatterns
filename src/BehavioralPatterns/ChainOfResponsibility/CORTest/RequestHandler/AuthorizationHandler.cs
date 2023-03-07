namespace CORTest;

internal class AuthorizationHandler : IHandler
{
    public bool Ok { get; }

    public AuthorizationHandler(bool ok) => Ok = ok;

    public async Task Handle(RequestContext context, RequestHandler next)
    {
        // Do something

        if (!Ok)
        {
            context.Authorized = false;
            return;
        }

        context.Authorized = true;
        await next(context);
    }
}
