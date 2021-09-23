using Verse;

namespace LingGame
{
    public class LingXCG_Anochlesia : HediffWithComps
    {
        private readonly int Dtick = 300;
        private int tick;

        public override void Tick()
        {
            base.Tick();
            tick++;
            if (tick <= Dtick)
            {
                return;
            }

            if (pawn.mindState.mentalStateHandler.CurState != null)
            {
                pawn.mindState.mentalStateHandler.CurState.RecoverFromState();
            }

            tick = 0;
        }
    }
}