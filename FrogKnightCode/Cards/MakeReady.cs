using FrogKnight.FrogKnightCode.Cards;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;

namespace FrogKnight.FrogKnightCode.Cards;

public class MakeReady() : FrogKnightCard(3,
    CardType.Power, CardRarity.Uncommon,
    TargetType.Self)
{
    public override string CustomPortraitPath => "res://FrogKnight/images/card_portraits/makeready.png";
    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[3]
    {
        new PowerVar<StrengthPower>(1),
        new PowerVar<DexterityPower>(1),
        new PowerVar<PlatingPower>(1)
    };

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        await CreatureCmd.TriggerAnim(base.Owner.Creature, "Cast", base.Owner.Character.CastAnimDelay);
        await PowerCmd.Apply<PlatingPower>(choiceContext, base.Owner.Creature, base.DynamicVars["PlatingPower"].BaseValue, base.Owner.Creature, this);
        await PowerCmd.Apply<StrengthPower>(choiceContext, base.Owner.Creature, base.DynamicVars["StrengthPower"].BaseValue, base.Owner.Creature, this);
        await PowerCmd.Apply<DexterityPower>(choiceContext, base.Owner.Creature, base.DynamicVars["DexterityPower"].BaseValue, base.Owner.Creature, this);
    }

    protected override void OnUpgrade()
    {
    base.EnergyCost.UpgradeBy(-1);
    }
}