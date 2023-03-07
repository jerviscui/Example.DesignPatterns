namespace CORTest;

internal class ValidationHandler : IHandler
{
    /// <inheritdoc />
    public async Task Handle(RequestContext context, RequestHandler next)
    {
        if (context.Authorized)
        {
            context.ValidateFailed = false;
            await next(context);

            //result
        }
        else
        {
            context.ValidateFailed = true;
        }
    }
}
