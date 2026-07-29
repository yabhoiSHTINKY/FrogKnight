using FrogKnight.FrogKnightCode.Cards;
using FrogKnight.FrogKnightCode.Powers;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace FrogKnight.FrogKnightCode.Cards;

public class DefendingPeaceFrog() : FrogKnightCard(2,
    CardType.Power, CardRarity.Rare,
    TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[]
    {
        new PowerVar<DefendingPeaceFrogPower>(1)
    };
    
    public override string CustomPortraitPath => "res://FrogKnight/images/card_portraits/defendpeace.png";

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        await CreatureCmd.TriggerAnim(base.Owner.Creature, "Cast", base.Owner.Character.CastAnimDelay);
        await PowerCmd.Apply<DefendingPeaceFrogPower>(choiceContext, base.Owner.Creature, base.DynamicVars["DefendingPeaceFrogPower"].BaseValue, base.Owner.Creature, this);
    }

    protected override void OnUpgrade()
    {
        base.EnergyCost.UpgradeBy(-1);
    }
}