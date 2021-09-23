using Verse;

namespace LingGame
{
    public class LingXCG_FightPuppetC : HediffWithComps
    {
        public override void Tick()
        {
            base.Tick();
            pawn.ageTracker.AgeBiologicalTicks += 99L;
        }
    }
}