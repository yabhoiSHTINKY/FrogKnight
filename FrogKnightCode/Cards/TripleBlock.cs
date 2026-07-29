using FrogKnight.FrogKnightCode.Cards;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;

namespace FrogKnight.FrogKnightCode.Cards;


public class TripleBlock() : FrogKnightCard(2,
    CardType.Skill, CardRarity.Common,
    TargetType.Self)
{
    public override string CustomPortraitPath => "res://FrogKnight/images/card_portraits/TripleBlock.png";

    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[2]
    {
        new BlockVar(3, ValueProp.Move),
        new RepeatVar(3),
    };
    public static void RepeatAction(int repeatCount, Action action)
    {
        for (int i = 0; i < repeatCount; i++)
            action();
    }
    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        RepeatAction(3, () =>
        {
            CreatureCmd.GainBlock(base.Owner.Creature, base.DynamicVars.Block, play);
        });
    }

    protected override void OnUpgrade()
    {
        base.DynamicVars.Block.UpgradeValueBy(1m);
        base.EnergyCost.UpgradeBy(-1);
    }
}