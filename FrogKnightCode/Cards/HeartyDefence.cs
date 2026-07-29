using FrogKnight.FrogKnightCode.Cards;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;

namespace FrogKnight.FrogKnightCode.Cards;

public class HeartyDefence() : FrogKnightCard(1,
    CardType.Skill, CardRarity.Common,
    TargetType.Self)
{
    public override string CustomPortraitPath => "res://FrogKnight/images/card_portraits/heartydefence.png";
    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[2]
    {
        new BlockVar(6m, ValueProp.Move),
        new PowerVar<VigorPower>(3m)
    };

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
            await CreatureCmd.GainBlock(base.Owner.Creature, base.DynamicVars.Block, play); 
            await PowerCmd.Apply<VigorPower>(choiceContext, base.Owner.Creature,
                base.DynamicVars["VigorPower"].BaseValue, base.Owner.Creature, this);
    }

    protected override void OnUpgrade()
    {
        base.DynamicVars.Block.UpgradeValueBy(4m);
    }
}