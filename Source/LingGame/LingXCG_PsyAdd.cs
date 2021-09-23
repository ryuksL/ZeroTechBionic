using Verse;

namespace LingGame
{
    public class LingXCG_PsyAdd : HediffWithComps
    {
        private int tti;

        public override void Tick()
        {
            base.Tick();
            tti++;
            if (tti < 60)
            {
                return;
            }

            tti = 0;
            pawn.psychicEntropy?.OffsetPsyfocusDirectly(0.01f);
        }
    }
}