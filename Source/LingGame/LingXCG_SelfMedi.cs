using RimWorld;
using Verse;

namespace LingGame
{
    public class LingXCG_SelfMedi : HediffWithComps
    {
        private readonly int Tendtick = 60;
        private int tick;

        public override void Tick()
        {
            base.Tick();
            tick++;
            if (tick <= Tendtick)
            {
                return;
            }

            // Hediffs can change
            // ReSharper disable once ForCanBeConvertedToForeach
            for (var i = 0; i < pawn.health.hediffSet.hediffs.Count; i++)
            {
                if (!pawn.health.hediffSet.hediffs[i].TendableNow() ||
                    pawn.health.hediffSet.hediffs[i] is Hediff_Injury)
                {
                    continue;
                }

                var num = 0.5f;
                if (pawn.skills.GetSkill(SkillDefOf.Medicine) != null &&
                    pawn.skills.GetSkill(SkillDefOf.Medicine).Level > 5)
                {
                    num = pawn.skills.GetSkill(SkillDefOf.Medicine).Level / 10f;
                }

                pawn.health.hediffSet.hediffs[i].Tended(num, 0);
                break;
            }

            tick = 0;
        }
    }
}