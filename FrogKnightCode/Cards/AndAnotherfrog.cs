using FrogKnight.FrogKnightCode.Cards;
using MegaCrit.Sts2.Core.CardSelection;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;

namespace FrogKnight.FrogKnightCode.Cards;


public class AndAnotherfrog() : FrogKnightCard(0,
    CardType.Skill, CardRarity.Uncommon,
    TargetType.Self)
{
    public override string CustomPortraitPath => "res://FrogKnight/images/card_portraits/andanother.png";
    public override IEnumerable<CardKeyword> CanonicalKeywords => new CardKeyword[]
    {
        CardKeyword.Exhaust
    };
    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[]
    {
        new BlockVar(3m, ValueProp.Move),
        new CardsVar(1)
    };

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        await CreatureCmd.GainBlock(base.Owner.Creature, base.DynamicVars.Block, play); 
        await CardPileCmd.Draw(choiceContext, DynamicVars.Cards.BaseValue, Owner);
 
    }

    protected override void OnUpgrade()
    {
        base.DynamicVars.Block.UpgradeValueBy(2);
    }
}