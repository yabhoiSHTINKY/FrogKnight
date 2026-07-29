using BaseLib.Patches.Content;
using FrogKnight.FrogKnightCode.Cards;
using FrogKnight.FrogKnightCode.Extensions;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;

namespace FrogKnight.FrogKnightCode.Cards;


public class SmackDown() : FrogKnightCard(1,
    CardType.Attack, CardRarity.Common,
    TargetType.AnyEnemy)
{
    [CustomEnum] public static CardTag Blow;
    
    public override string CustomPortraitPath => "res://FrogKnight/images/card_portraits/scryadd.png";
    
    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[2]
    {
        new DamageVar(5m, ValueProp.Move),
        new PowerVar<WeakPower>(3m)
    };

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        ArgumentNullException.ThrowIfNull(play.Target, "cardPlay.Target");
        try
        {
            await DamageCmd.Attack(base.DynamicVars.Damage.BaseValue).FromCard(this).Targeting(play.Target)
                .WithHitFx("vfx/vfx_attack_blunt", null, "blunt_attack.mp3")
                .Execute(choiceContext);
            await PowerCmd.Apply<WeakPower>(choiceContext, play.Target, base.DynamicVars.Weak.BaseValue,
                base.Owner.Creature, this);
        }
        catch (Exception ex)
        {
            Godot.GD.PrintErr($"[StrikeFrogKnight] Error in OnPlay: " + ex);
        } 
    }

    protected override void OnUpgrade()
    {
        base.DynamicVars.Damage.UpgradeValueBy(2m);
        base.DynamicVars.Weak.UpgradeValueBy(2m);
    }
}