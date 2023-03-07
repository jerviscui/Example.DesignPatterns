namespace CORTest
{
    public class RequestHandlerTests
    {
        [Fact]
        public async Task Authorize_True_Test()
        {
            var chain = new HandlerChain();
            chain.AddHandler(new LogHandler());
            chain.AddHandler(new AuthorizationHandler(true));
            chain.AddHandler(new ValidationHandler());

            bool authorized = false;
            bool? validateFailed = true;
            var requestHandler = chain.Build(context =>
            {
                authorized = context.Authorized;
                validateFailed = context.ValidateFailed;

                return Task.CompletedTask;
            });

            var context = new RequestContext();
            await requestHandler(context);

            authorized.ShouldBeTrue();
            validateFailed.ShouldNotBeNull().ShouldBeFalse();
        }

        [Fact]
        public async Task Authorize_False_Test()
        {
            var chain = new HandlerChain();
            chain.AddHandler(new LogHandler());
            chain.AddHandler(new AuthorizationHandler(false));
            chain.AddHandler(new ValidationHandler());

            bool authorized = true;
            bool? validateFailed = true;
            var requestHandler = chain.Build(context =>
            {
                //will skip
                authorized = context.Authorized;
                validateFailed = context.ValidateFailed;

                return Task.CompletedTask;
            });

            var context = new RequestContext();
            await requestHandler(context);

            authorized.ShouldBeTrue();
            validateFailed.ShouldNotBeNull().ShouldBeTrue();
        }
    }
}
