using FrogKnight.FrogKnightCode.Cards;
using FrogKnight.FrogKnightCode.Powers;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;

namespace FrogKnight.FrogKnightCode.Cards;

 
public class UnphasedFrog() : FrogKnightCard(1,
    CardType.Skill, CardRarity.Uncommon,
    TargetType.AnyEnemy)
{
    public override string CustomPortraitPath => "res://FrogKnight/images/card_portraits/unphased.png";
    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[]
    {
        new CardsVar(1),
        new DynamicVar("StrengthLoss",2)
    };
    public override IEnumerable<CardKeyword> CanonicalKeywords => new CardKeyword[]
    {
        CardKeyword.Exhaust
    };
    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        await PowerCmd.Apply<UnstableFootingPower>(choiceContext, play.Target ?? throw new InvalidOperationException(), base.DynamicVars["StrengthLoss"].BaseValue, base.Owner.Creature, this);
        try
        {
            for (int _i = 0; _i < 1; _i++)
            {
                var token = ((CardModel)this).CombatState?.CreateCard<InnerPeace>(((CardModel)this).Owner);
                if (token != null)
                    CardCmd.PreviewCardPileAdd(await CardPileCmd.AddGeneratedCardToCombat(
                        (CardModel)(object)token, PileType.Draw, Owner, CardPilePosition.Random));
            }
        }
        catch (Exception ex)
        {
            Godot.GD.PrintErr($"[KnightlyBlow] Error in OnPlay: " + ex);
        }
    }

    protected override void OnUpgrade()
    {
        base.DynamicVars.Cards.UpgradeValueBy(2);
        RemoveKeyword(CardKeyword.Exhaust);
    }
}