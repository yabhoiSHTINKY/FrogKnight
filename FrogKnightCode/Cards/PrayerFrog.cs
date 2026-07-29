using FrogKnight.FrogKnightCode.Cards;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;

namespace FrogKnight.FrogKnightCode.Cards;


public class PrayerFrog() : FrogKnightCard(2,
    CardType.Skill, CardRarity.Rare,
    TargetType.Self)
{
    public override string CustomPortraitPath => "res://FrogKnight/images/card_portraits/prayerfrog.png";
    public override IEnumerable<CardKeyword> CanonicalKeywords => new CardKeyword[]
    {
        CardKeyword.Exhaust
    };
    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[]
    {
    };

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        List<CardModel> list = GetStatuses(base.Owner).ToList();
        foreach (CardModel item in list)
        {
            await CardCmd.Exhaust(choiceContext, item);
            await CardPileCmd.AddToCombatAndPreview<InnerPeace>(Owner.Creature, PileType.Draw, 1, Owner);
        }
    }
    private static IEnumerable<CardModel> GetStatuses(Player owner)
    {
        return owner.PlayerCombatState?.AllCards.Where((CardModel c) => c.Type == CardType.Status && c?.Pile?.Type != PileType.Exhaust) ?? throw new InvalidOperationException();
    }


    protected override void OnUpgrade()
    {
        base.EnergyCost.UpgradeBy(-1);
        RemoveKeyword(CardKeyword.Exhaust);
    }
}