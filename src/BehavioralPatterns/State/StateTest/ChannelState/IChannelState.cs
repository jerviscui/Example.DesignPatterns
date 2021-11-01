namespace StateTest
{
    /// <summary>
    /// 通道状态迁移事件
    /// </summary>
    public interface IChannelState
    {
        /// <summary>
        /// 车牌识别信号
        /// </summary>
        public bool ReceiveNumber();

        /// <summary>
        /// 识别失败
        /// </summary>
        public void RecognizeFailed();

        /// <summary>
        /// 入场
        /// </summary>
        public bool IsEnter(RecognizeEventData data);

        /// <summary>
        /// 出场
        /// </summary>
        public bool IsLeave(RecognizeEventData data);

        /// <summary>
        /// 开闸
        /// </summary>
        public void OpenDoor();

        /// <summary>
        /// 已通过
        /// </summary>
        public void Passed();

        /// <summary>
        /// 支付失败
        /// </summary>
        public void PayFailed();

        /// <summary>
        /// 禁止进入
        /// </summary>
        public void BarredEntery();
    }
}
