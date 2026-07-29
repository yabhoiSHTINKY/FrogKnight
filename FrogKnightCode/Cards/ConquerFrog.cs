using FrogKnight.FrogKnightCode.Cards;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;

namespace FrogKnight.FrogKnightCode.Cards;

public class ConquerFrog() : FrogKnightCard(1,
    CardType.Skill, CardRarity.Rare,
    TargetType.AnyEnemy)
{
    public override IEnumerable<CardKeyword> CanonicalKeywords => new CardKeyword[]
    {
        CardKeyword.Exhaust
    };

    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[2]
    {
        new PowerVar<WeakPower>(1m),
        new DynamicVar("StrengthPerWeak", 1m)
    };

    public override string CustomPortraitPath => "res://FrogKnight/images/card_portraits/Conquer.png";

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        await CreatureCmd.TriggerAnim(base.Owner.Creature, "Cast", base.Owner.Character.CastAnimDelay);
        ArgumentNullException.ThrowIfNull(play.Target, "cardPlay.Target");
        await CreatureCmd.TriggerAnim(base.Owner.Creature, "Cast", base.Owner.Character.CastAnimDelay);
        await PowerCmd.Apply<WeakPower>(choiceContext, play.Target, base.DynamicVars["WeakPower"].BaseValue, base.Owner.Creature, this);
        int num = play.Target.GetPower<WeakPower>()?.Amount ?? 0;
        await PowerCmd.Apply<StrengthPower>(choiceContext, base.Owner.Creature, num, base.Owner.Creature, this);
    }

    protected override void OnUpgrade()
    {
        base.DynamicVars["WeakPower"].UpgradeValueBy(1m);
    }
}