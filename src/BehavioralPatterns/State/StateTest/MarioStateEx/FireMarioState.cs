namespace StateTest
{
    public class FireMarioState : MarioState
    {
        /// <inheritdoc />
        public FireMarioState(MarioStateContext marioStateContext) : base(marioStateContext)
        {
        }

        /// <inheritdoc />
        public override void TouchMonster()
        {
            MarioStateContext.SetState(new SmallMarioState(MarioStateContext));
            MarioStateContext.SetScore(-300);
        }

        /// <inheritdoc />
        protected override void Entry()
        {
            MarioStateContext.SetScore(+300);
        }
    }
}
