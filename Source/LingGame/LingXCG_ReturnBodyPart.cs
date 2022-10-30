using Verse;

namespace LingGame;

public class LingXCG_ReturnBodyPart : HediffWithComps
{
    private readonly int Healtick = 60;
    private int tick;

    public override string LabelInBrackets => Severity.ToStringPercent();

    public override void Tick()
    {
        base.Tick();
        tick++;
        if (tick <= Healtick || !(Severity > 0.1f))
        {
            return;
        }

        // Hediffs can change
        // ReSharper disable once ForCanBeConvertedToForeach
        for (var i = 0; i < pawn.health.hediffSet.hediffs.Count; i++)
        {
            if (pawn.health.hediffSet.hediffs[i] is not Hediff_MissingPart hediff_MissingPart)
            {
                continue;
            }

            Severity -= 0.1f;
            pawn.health.RestorePart(hediff_MissingPart.Part);
        }

        tick = 0;
    }
}