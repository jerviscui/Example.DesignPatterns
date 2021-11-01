namespace StateTest
{
    /// <summary>
    /// 管理通道状态
    /// </summary>
    public sealed class ChannelStateContext : IChannelState
    {
        public ChannelStateContext()
        {
            SetCurrentState(new WaitState(this));
        }

        private IChannelState CurrentState { get; set; }

        public bool IsRunning { get; set; }

        /// <summary>
        /// Sets the state of the current.
        /// </summary>
        /// <param name="state">The state.</param>
        public void SetCurrentState(IChannelState state) => CurrentState = state;

        /// <inheritdoc />
        public bool ReceiveNumber() => CurrentState.ReceiveNumber();

        /// <inheritdoc />
        public void RecognizeFailed() => CurrentState.RecognizeFailed();

        /// <inheritdoc />
        public bool IsEnter(RecognizeEventData data) => CurrentState.IsEnter(data);

        /// <inheritdoc />
        public bool IsLeave(RecognizeEventData data) => CurrentState.IsLeave(data);

        /// <inheritdoc />
        public void OpenDoor() => CurrentState.OpenDoor();

        /// <inheritdoc />
        public void Passed() => CurrentState.Passed();

        /// <inheritdoc />
        public void PayFailed() => CurrentState.Passed();

        /// <inheritdoc />
        public void BarredEntery() => CurrentState.Passed();
    }
}
