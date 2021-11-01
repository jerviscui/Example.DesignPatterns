using System.Collections.Generic;
using Shouldly;
using TestBase;
using Xunit;

namespace StateTest
{
    public class ChannelStateTests : BaseTest
    {
        private readonly Dictionary<string, ChannelStateContext> _stateContexts = new();

        private const string ChannelKey = "channel-1";

        private ChannelStateContext GetContext() => _stateContexts.GetValueOrDefault(ChannelKey)!;

        public ChannelStateTests()
        {
            var stateContext = new ChannelStateContext();

            //save context
            _stateContexts.Add("channel-1", stateContext);
        }

        [Fact]
        public void ReceiveNumber_OnlyOneSuccess()
        {
            //new signal

            var stateContext = GetContext();
            var firstSignal = stateContext.ReceiveNumber();
            var secondSignal = stateContext.ReceiveNumber();

            firstSignal.ShouldBeTrue();
            secondSignal.ShouldBeFalse();
        }

        [Fact]
        public void RecognizeFailed_RecognizingState_ToWaitState_Test()
        {
            var stateContext = GetContext();
            stateContext.SetCurrentState(new RecognizingState(stateContext));

            stateContext.RecognizeFailed();

            stateContext.IsRunning.ShouldBeFalse();
        }

        [Fact]
        public void WaitStateToPassed_Test()
        {
            var stateContext = GetContext();

            stateContext.Passed();

            //there is nothing
        }

        [Fact]
        public void IsEnter_DirectionOnlyIn_Success()
        {
            //check enter or leave
            //check direction

            var eventData = new RecognizeEventData { IsEnter = true, Direction = Direction.OnlyIn };
            var stateContext = GetContext();
            stateContext.SetCurrentState(new RecognizingState(stateContext));

            var success = stateContext.IsEnter(eventData);

            success.ShouldBeTrue();
        }

        [Fact]
        public void IsEnter_DirectionBothway_Success()
        {
            //check enter or leave
            //check direction

            var eventData = new RecognizeEventData { IsEnter = true, Direction = Direction.Bothway };
            var stateContext = GetContext();
            stateContext.SetCurrentState(new RecognizingState(stateContext));

            var success = stateContext.IsEnter(eventData);

            success.ShouldBeTrue();
        }

        [Fact]
        public void IsEnter_DirectionOnlyOut_Failed()
        {
            //check enter or leave
            //check direction

            var eventData = new RecognizeEventData { IsEnter = true, Direction = Direction.OnlyOut };
            var stateContext = GetContext();
            stateContext.SetCurrentState(new RecognizingState(stateContext));

            var success = stateContext.IsEnter(eventData);

            success.ShouldBeFalse();
        }

        [Fact]
        public void PayFailed_ReadyEnterState_ToWaitState_Test()
        {
            var stateContext = GetContext();
            stateContext.SetCurrentState(new ReadyEnterState(stateContext));

            stateContext.PayFailed();

            stateContext.IsRunning.ShouldBeFalse();
        }

        [Fact]
        public void BarredEntery_ReadyEnterState_ToWaitState_Test()
        {
            var stateContext = GetContext();
            stateContext.SetCurrentState(new ReadyEnterState(stateContext));

            stateContext.BarredEntery();

            stateContext.IsRunning.ShouldBeFalse();
        }

        [Fact]
        public void IsLeave_DirectionOnlyOut_Success()
        {
            //check enter or leave
            //check direction

            var eventData = new RecognizeEventData { IsEnter = false, Direction = Direction.OnlyOut };
            var stateContext = GetContext();
            stateContext.SetCurrentState(new RecognizingState(stateContext));

            var success = stateContext.IsLeave(eventData);

            success.ShouldBeTrue();
        }

        [Fact]
        public void PayFailed_ReadyLeaveState_ToWaitState_Test()
        {
            var stateContext = GetContext();
            stateContext.SetCurrentState(new ReadyLeaveState(stateContext));

            stateContext.PayFailed();

            stateContext.IsRunning.ShouldBeFalse();
        }

        [Fact]
        public void Passed_EnteringState_ToWaitState_Test()
        {
            var stateContext = GetContext();
            stateContext.SetCurrentState(new EnteringState(stateContext));

            stateContext.Passed();

            stateContext.IsRunning.ShouldBeFalse();
        }

        [Fact]
        public void Passed_LeavingState_ToWaitState_Test()
        {
            var stateContext = GetContext();
            stateContext.SetCurrentState(new LeavingState(stateContext));

            stateContext.Passed();

            stateContext.IsRunning.ShouldBeFalse();
        }
    }
}
