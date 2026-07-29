using FrogKnight.FrogKnightCode.Cards;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;

namespace FrogKnight.FrogKnightCode.Cards;

  
public class HeartyBlowFrog() : FrogKnightCard(1,
    CardType.Attack, CardRarity.Common,
    TargetType.AnyEnemy)
{
    public override string CustomPortraitPath => "res://FrogKnight/images/card_portraits/HeartyBlow.png";

    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[2]
    {
        new DamageVar(6m, ValueProp.Move),
        new PowerVar<VigorPower>(3m)
    };

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        ArgumentNullException.ThrowIfNull(play.Target, "cardPlay.Target");
        try
        {
            await DamageCmd.Attack(base.DynamicVars.Damage.BaseValue).FromCard(this).Targeting(play.Target)
                .Execute(choiceContext);
            await PowerCmd.Apply<VigorPower>(choiceContext, base.Owner.Creature,
                base.DynamicVars["VigorPower"].BaseValue, base.Owner.Creature, this);
        }
        catch (Exception ex)
        {
            Godot.GD.PrintErr($"[StrikeFrogKnight] Error in OnPlay: " + ex);
        }  
    }

    protected override void OnUpgrade()
    {
        base.DynamicVars.Damage.UpgradeValueBy(4m);
    }
}