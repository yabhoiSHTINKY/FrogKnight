using FrogKnight.FrogKnightCode.Cards;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;

namespace FrogKnight.FrogKnightCode.Cards;

public class TruePeaceFrog() : FrogKnightCard(3,
    CardType.Skill, CardRarity.Rare,
    TargetType.Self)
{
    public override IEnumerable<CardKeyword> CanonicalKeywords => new CardKeyword[]
    {
        CardKeyword.Exhaust
    };
    public override string CustomPortraitPath => "res://FrogKnight/images/card_portraits/truepeace.png";
    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[]
    {
        new CardsVar(5)
    };

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        await CreatureCmd.TriggerAnim(base.Owner.Creature, "Cast", base.Owner.Character.CastAnimDelay);
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
            Godot.GD.PrintErr($"[TakeAMoment] Error in OnPlay: " + ex);
        } 
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
            Godot.GD.PrintErr($"[TakeAMoment] Error in OnPlay: " + ex);
        } 
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
            Godot.GD.PrintErr($"[TakeAMoment] Error in OnPlay: " + ex);
        } 
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
            Godot.GD.PrintErr($"[TakeAMoment] Error in OnPlay: " + ex);
        } 
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
            Godot.GD.PrintErr($"[TakeAMoment] Error in OnPlay: " + ex);
        } 
    }

    protected override void OnUpgrade()
    {
        base.EnergyCost.UpgradeBy(-1);
    }
}