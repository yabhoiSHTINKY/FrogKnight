using FrogKnight.FrogKnightCode.Cards;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;

namespace FrogKnight.FrogKnightCode.Cards;


public class GrappleBlock() : FrogKnightCard(1,
    CardType.Skill, CardRarity.Uncommon,
    TargetType.AllEnemies)
{
    public override string CustomPortraitPath => "res://FrogKnight/images/card_portraits/grappleblock.png";
    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[2]
    {
        new BlockVar(3m, ValueProp.Move),
        new PowerVar<WeakPower>(1)
    };
    
    protected override IEnumerable<IHoverTip> ExtraHoverTips => new IHoverTip[]
    {
        HoverTipFactory.FromPower<ConstrictPower>(),
        HoverTipFactory.FromPower<WeakPower>()
    };


    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        await CreatureCmd.TriggerAnim(base.Owner.Creature, "Cast", base.Owner.Character.CastAnimDelay);
        await CreatureCmd.GainBlock(base.Owner.Creature, base.DynamicVars.Block, play); 
        await PowerCmd.Apply<ConstrictPower>(choiceContext, base.CombatState!.HittableEnemies, base.DynamicVars.Weak.BaseValue, base.Owner.Creature, this);
    }

    protected override void OnUpgrade()
    {
        base.DynamicVars.Block.UpgradeValueBy(2m);
        base.DynamicVars.Weak.UpgradeValueBy(1m);
    }
}