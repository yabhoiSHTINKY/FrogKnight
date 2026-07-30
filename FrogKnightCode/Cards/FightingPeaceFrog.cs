using FrogKnight.FrogKnightCode.Cards;
using FrogKnight.FrogKnightCode.Powers;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;

namespace FrogKnight.FrogKnightCode.Cards;


public class FightingPeaceFrog() : FrogKnightCard(2,
    CardType.Power, CardRarity.Rare,
    TargetType.Self)
{
    
    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[]
    {
        new PowerVar<FightingPeaceFrogPower>(3)
    };
    
    protected override IEnumerable<IHoverTip> ExtraHoverTips => new IHoverTip[]
    {
        HoverTipFactory.FromPower<FightingPeaceFrogPower>(),
        HoverTipFactory.FromCard<InnerPeace>(),
        HoverTipFactory.FromPower<VigorPower>(),
        HoverTipFactory.FromPower<PlatingPower>()
    };

    public override string CustomPortraitPath => "res://FrogKnight/images/card_portraits/fightingpeace.png";

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        await CreatureCmd.TriggerAnim(base.Owner.Creature, "Cast", base.Owner.Character.CastAnimDelay);
        await PowerCmd.Apply<FightingPeaceFrogPower>(choiceContext, base.Owner.Creature,
            base.DynamicVars["FightingPeaceFrogPower"].BaseValue, base.Owner.Creature, this);
    }

    protected override void OnUpgrade()
    {
        base.EnergyCost.UpgradeBy(-1);
    }
}