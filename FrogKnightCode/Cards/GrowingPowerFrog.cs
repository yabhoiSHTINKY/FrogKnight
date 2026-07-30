using FrogKnight.FrogKnightCode.Cards;
using FrogKnight.FrogKnightCode.Powers;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;

namespace FrogKnight.FrogKnightCode.Cards;

public class GrowingPowerFrog() : FrogKnightCard(2,
    CardType.Power, CardRarity.Uncommon,
    TargetType.Self)
{
    public override string CustomPortraitPath => "res://FrogKnight/images/card_portraits/Growingpower.png";

    
    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[]
    {
        new PowerVar<GrowingPowerFrogPower>(2m)
    };
    
    protected override IEnumerable<IHoverTip> ExtraHoverTips => new IHoverTip[]
    {
        HoverTipFactory.FromPower<VigorPower>()
    };

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        try
        {
            await CreatureCmd.TriggerAnim(base.Owner.Creature, "Cast", base.Owner.Character.CastAnimDelay);
            await PowerCmd.Apply<GrowingPowerFrogPower>(choiceContext, base.Owner.Creature, base.DynamicVars["GrowingPowerFrogPower"].BaseValue, base.Owner.Creature, this);
        }
        catch (Exception ex)
        {
            Godot.GD.PrintErr($"[GrowingPower] Error in OnPlay: " + ex);
        }
    }

    protected override void OnUpgrade()
    {
        base.EnergyCost.UpgradeBy(-1);
    }
}