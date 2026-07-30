using FrogKnight.FrogKnightCode.Cards;
using FrogKnight.FrogKnightCode.Powers;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;

namespace FrogKnight.FrogKnightCode.Cards;


public class RecklessFrog() : FrogKnightCard(3,
    CardType.Power, CardRarity.Rare,
    TargetType.Self)
{
    public override string CustomPortraitPath => "res://FrogKnight/images/card_portraits/reckless.png";
    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[3]
    {
        new PowerVar<DexterityPower>(-2),
        new PowerVar<RecklessFrogPower>(1),
        new EnergyVar(1)
    };

    protected override IEnumerable<IHoverTip> ExtraHoverTips => new IHoverTip[]
    {
        HoverTipFactory.FromPower<RecklessFrogPower>(),
        HoverTipFactory.FromPower<DexterityPower>()
    };

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        await CreatureCmd.TriggerAnim(base.Owner.Creature, "Cast", base.Owner.Character.CastAnimDelay);
        await PowerCmd.Apply<DexterityPower>(choiceContext, base.Owner.Creature, base.DynamicVars["DexterityPower"].BaseValue, base.Owner.Creature, this);
        await PowerCmd.Apply<RecklessFrogPower>(choiceContext, base.Owner.Creature, base.DynamicVars["RecklessFrogPower"].BaseValue, base.Owner.Creature, this);
    }

    protected override void OnUpgrade()
    {
        base.EnergyCost.UpgradeBy(-1);
    }
}