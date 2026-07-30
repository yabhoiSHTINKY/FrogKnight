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


public class BreakTheirWill() : FrogKnightCard(0,
    CardType.Attack, CardRarity.Rare,
    TargetType.AnyEnemy)
{
    public override string CustomPortraitPath => "res://FrogKnight/images/card_portraits/breakingwill.png";
    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[3]
    {
        new DamageVar(1,ValueProp.Move),
        new PowerVar<WeakPower>(1),
        new PowerVar<VulnerablePower>(1)
    };
    
    protected override IEnumerable<IHoverTip> ExtraHoverTips => new IHoverTip[]
    {
        HoverTipFactory.FromPower<WeakPower>(),
        HoverTipFactory.FromPower<VulnerablePower>(),
        HoverTipFactory.FromCard<Debris>()
    };

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        if (play.Target != null)
            await DamageCmd.Attack(base.DynamicVars.Damage.BaseValue)
                .FromCard(this).Targeting(play.Target)
                .WithHitVfxSpawnedAtBase()
                .Execute(choiceContext);
        if (play.Target != null)
            await PowerCmd.Apply<WeakPower>(choiceContext, play.Target, base.DynamicVars.Weak.BaseValue,
                base.Owner.Creature, this);
        if (play.Target != null)
            await PowerCmd.Apply<VulnerablePower>(choiceContext, play.Target, base.DynamicVars.Weak.BaseValue,
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
            Godot.GD.PrintErr($"[BreakTheirWill] Error in OnPlay: " + ex);
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
            Godot.GD.PrintErr($"[BreakTheirWill] Error in OnPlay: " + ex);
        }
    }

    protected override void OnUpgrade()
    {
        base.DynamicVars.Damage.UpgradeValueBy(4m);
        base.DynamicVars.Weak.UpgradeValueBy(1m);
        base.DynamicVars.Vulnerable.UpgradeValueBy(1m);
    }
} 
    

