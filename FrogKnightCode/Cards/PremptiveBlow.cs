using BaseLib.Abstracts;
using FrogKnight.FrogKnightCode.Cards;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;

namespace FrogKnight.FrogKnightCode.Cards;


public class PremptiveBlow() : FrogKnightCard(1,
    CardType.Attack, CardRarity.Common,
    TargetType.AnyEnemy)
{
    public override bool GainsBlock => true;

    public override string CustomPortraitPath => "res://FrogKnight/images/card_portraits/Bonk.png";

    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[2]
    {
        new DamageVar(5m, ValueProp.Move),
        new BlockVar(5m, ValueProp.Move)
        
    };

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        ArgumentNullException.ThrowIfNull(play.Target, "cardPlay.Target");
        try
        {
            await DamageCmd.Attack(base.DynamicVars.Damage.BaseValue)
                .FromCard(this).Targeting(play.Target)
                .WithHitFx("vfx/vfx_attack_slash", null, "blunt_attack.mp3")
                .Execute(choiceContext);
            await CreatureCmd.GainBlock(base.Owner.Creature, base.DynamicVars.Block, play); 
        }
        catch (Exception ex)
        {
            Godot.GD.PrintErr($"[StrikeFrogKnight] Error in OnPlay: " + ex);
        } 
    }

    protected override void OnUpgrade()
    {
        base.DynamicVars.Damage.UpgradeValueBy(3m);
        base.DynamicVars.Block.UpgradeValueBy(3m);
    }
}