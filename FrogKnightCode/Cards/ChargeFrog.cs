using BaseLib.Extensions;
using BaseLib.Patches.Features;
using BaseLib.Utils;
using FrogKnight.FrogKnightCode.Cards;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Commands.Builders;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;

namespace FrogKnight.FrogKnightCode.Cards;


public class ChargeFrog() : FrogKnightCard(1,
    CardType.Attack, CardRarity.Uncommon,
    TargetType.AllEnemies)
{
    public override string CustomPortraitPath => "res://FrogKnight/images/card_portraits/Charge.png";

    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[3]
    {
        new DamageVar(4m, ValueProp.Move),
        new PowerVar<WeakPower>(1m),
        new PowerVar<WeakPower>("FollowupWeakPower",1)
    };

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {

        await DamageCmd.Attack(DynamicVars.Damage.BaseValue)
            .FromCard(this)
            .TargetingFiltered(this.GetTargets())
            .Execute(choiceContext);
        await PowerCmd.Apply<WeakPower>(choiceContext, base.CombatState!.HittableEnemies, base.DynamicVars.Weak.BaseValue, base.Owner.Creature, this);
           
    }

    protected override void OnUpgrade()
    {
        base.DynamicVars.Damage.UpgradeValueBy(3m);
        base.DynamicVars.Weak.UpgradeValueBy(2m);
    }
}