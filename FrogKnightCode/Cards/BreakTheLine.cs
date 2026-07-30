using BaseLib.Extensions;
using BaseLib.Patches.Features;
using FrogKnight.FrogKnightCode.Cards;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;

namespace FrogKnight.FrogKnightCode.Cards;

public class BreakTheLine() : FrogKnightCard(2,
    CardType.Attack, CardRarity.Uncommon,
    TargetType.AllEnemies)
{
    public override string CustomPortraitPath => "res://FrogKnight/images/card_portraits/breaktheline.png";
    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[4]
    {
        new PowerVar<WeakPower>(3),
        new PowerVar<StrengthPower>(-1),
        new CardsVar(2),
        new DamageVar(4m, ValueProp.Move)
    };
    public override IEnumerable<CardKeyword> CanonicalKeywords => new CardKeyword[]
    {
        CardKeyword.Exhaust
    };
    
    protected override IEnumerable<IHoverTip> ExtraHoverTips => new IHoverTip[]
    {
        HoverTipFactory.FromPower<WeakPower>(),
        HoverTipFactory.FromPower<StrengthPower>(),
        HoverTipFactory.FromCard<Debris>()
    };

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        ArgumentNullException.ThrowIfNull(play.Target, "cardPlay.Target");
        try
        {
            await DamageCmd.Attack(DynamicVars.Damage.BaseValue)
                .FromCard(this)
                .TargetingFiltered(this.GetTargets())
                .Execute(choiceContext);
            await PowerCmd.Apply<WeakPower>(choiceContext, play.Target, base.DynamicVars.Weak.BaseValue,
                base.Owner.Creature, this);
            await PowerCmd.Apply<StrengthPower>(choiceContext, play.Target, base.DynamicVars.Weak.BaseValue,
                base.Owner.Creature, this);
            try
            {
                for (int _i = 0; _i < 1; _i++)
                {
                    var token = ((CardModel)this).CombatState?.CreateCard<Debris>(((CardModel)this).Owner);
                    if (token != null)
                        CardCmd.PreviewCardPileAdd(await CardPileCmd.AddGeneratedCardToCombat(
                            (CardModel)(object)token, PileType.Hand, Owner, CardPilePosition.Random));
                }
            }
            catch (Exception ex)
            {
                Godot.GD.PrintErr($"[BreakTheLine] Error in OnPlay: " + ex);
            }

            try
            {
                for (int _i = 0; _i < 1; _i++)
                {
                    var token = ((CardModel)this).CombatState?.CreateCard<Debris>(((CardModel)this).Owner);
                    if (token != null)
                        CardCmd.PreviewCardPileAdd(await CardPileCmd.AddGeneratedCardToCombat(
                            (CardModel)(object)token, PileType.Hand, Owner, CardPilePosition.Random));
                }
            }
            catch (Exception ex)
            {
                Godot.GD.PrintErr($"[BreakTheLine] Error in OnPlay: " + ex);
            }
        }
        catch (Exception ex)
        {
            Godot.GD.PrintErr($"[BreakTheLine] Error in OnPlay: " + ex);
        }
    }

    protected override void OnUpgrade()
    {
        base.EnergyCost.UpgradeBy(-1);
    }
}