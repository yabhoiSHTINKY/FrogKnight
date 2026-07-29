using FrogKnight.FrogKnightCode.Cards;
using Godot;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using Microsoft.VisualBasic.CompilerServices;

namespace FrogKnight.FrogKnightCode.Cards;

public class InnerPeace() : FrogKnightCard(0,
    CardType.Skill, CardRarity.Basic,
    TargetType.Self)
{
    public override string CustomPortraitPath => "res://FrogKnight/images/card_portraits/InnerPeace.png";
    public override IEnumerable<CardKeyword> CanonicalKeywords => new CardKeyword[]
    {
        CardKeyword.Exhaust
    };
    protected override HashSet<CardTag> CanonicalTags => new HashSet<CardTag> { CardTag.Shiv };
    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[2]
    {
        new CardsVar(2),
        new DamageVar(2m,ValueProp.Move)
    };

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        await CardPileCmd.Draw(choiceContext, base.DynamicVars.Cards.BaseValue, base.Owner);
    }

    protected override void OnUpgrade()
    {

    }
}