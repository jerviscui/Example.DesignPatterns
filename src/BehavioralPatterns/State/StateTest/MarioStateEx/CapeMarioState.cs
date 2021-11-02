namespace StateTest
{
    public class CapeMarioState : MarioState
    {
        /// <inheritdoc />
        public CapeMarioState(MarioStateContext marioStateContext) : base(marioStateContext)
        {
        }

        /// <inheritdoc />
        public override void TouchMonster()
        {
            MarioStateContext.SetState(new SmallMarioState(MarioStateContext));
            MarioStateContext.SetScore(-200);
        }

        /// <inheritdoc />
        protected override void Entry()
        {
            MarioStateContext.SetScore(+200);
        }
    }
}
