using BaseLib.Extensions;
using BaseLib.Patches.Features;
using FrogKnight.FrogKnightCode.Cards;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;

namespace FrogKnight.FrogKnightCode.Cards;

public class FurrySwipes() : FrogKnightCard(2,
    CardType.Attack, CardRarity.Common,
    TargetType.AllEnemies)
{
    public override string CustomPortraitPath => "res://FrogKnight/images/card_portraits/furyswipes.png";
    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[]
    {
        new DamageVar(2,ValueProp.Move)
    };

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        await DamageCmd.Attack(DynamicVars.Damage.BaseValue)
            .WithHitCount(3)
            .FromCard(this)
            .TargetingFiltered(this.GetTargets())
            .Execute(choiceContext);
    }

    protected override void OnUpgrade()
    {
    base.DynamicVars.Damage.UpgradeValueBy(1);
    base.EnergyCost.UpgradeBy(-1);
    }
}