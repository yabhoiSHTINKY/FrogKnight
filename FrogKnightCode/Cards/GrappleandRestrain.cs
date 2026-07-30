using FrogKnight.FrogKnightCode.Cards;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;

namespace FrogKnight.FrogKnightCode.Cards;


public class GrappleandRestrain() : FrogKnightCard(1,
    CardType.Skill, CardRarity.Uncommon,
    TargetType.AllEnemies)
{
    public override string CustomPortraitPath => "res://FrogKnight/images/card_portraits/grestrain.png";
    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[2]
    {
        new CardsVar(1),
        new PowerVar<WeakPower>(1)
    };
    
    protected override IEnumerable<IHoverTip> ExtraHoverTips => new IHoverTip[]
    {
        HoverTipFactory.FromCard<InnerPeace>(),
        HoverTipFactory.FromPower<ConstrictPower>()
    };

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        await CreatureCmd.TriggerAnim(base.Owner.Creature, "Cast", base.Owner.Character.CastAnimDelay);
        await PowerCmd.Apply<ConstrictPower>(choiceContext, base.CombatState!.HittableEnemies, base.DynamicVars.Weak.BaseValue, base.Owner.Creature, this);
        try
        {
            for (int _i = 0; _i < 1; _i++)
            {
                var token = ((CardModel)this).CombatState?.CreateCard<InnerPeace>(((CardModel)this).Owner);
                if (token != null)
                    CardCmd.PreviewCardPileAdd(await CardPileCmd.AddGeneratedCardToCombat(
                        (CardModel)(object)token, PileType.Hand, Owner, CardPilePosition.Random));
            }
        }
        catch (Exception ex)
        {
            Godot.GD.PrintErr($"[GrappleandRestrain] Error in OnPlay: " + ex);
        } 
    }

    protected override void OnUpgrade()
    {
        base.DynamicVars.Weak.UpgradeValueBy(1m);
    }
}