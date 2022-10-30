using RimWorld;
using Verse;

namespace LingGame;

public class LingXCG_SelfHeal : HediffWithComps
{
    private readonly int Healtick = 60;
    private int tick;

    public override void Tick()
    {
        base.Tick();
        tick++;
        if (tick <= Healtick)
        {
            return;
        }

        // Hediffs can change
        // ReSharper disable once ForCanBeConvertedToForeach
        for (var i = 0; i < pawn.health.hediffSet.hediffs.Count; i++)
        {
            if (pawn.health.hediffSet.hediffs[i] is not Hediff_Injury hediff_Injury)
            {
                continue;
            }

            var amount = 0.5f;
            if (pawn.skills.GetSkill(SkillDefOf.Medicine) != null &&
                pawn.skills.GetSkill(SkillDefOf.Medicine).Level > 5)
            {
                amount = pawn.skills.GetSkill(SkillDefOf.Medicine).Level / 10f;
            }

            hediff_Injury.Heal(amount);
        }

        tick = 0;
    }
}