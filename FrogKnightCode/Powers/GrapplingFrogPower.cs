using FrogKnight.FrogKnightCode.Powers;
using Godot;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Helpers;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.Nodes.Combat;
using MegaCrit.Sts2.Core.Nodes.Rooms;
using MegaCrit.Sts2.Core.Nodes.Vfx;

namespace FrogKnight.FrogKnightCode.Powers;

public class GrapplingFrogPower() : FrogKnightPower
{
    
    public const string Key = "GrapplingFrogPower";
    
    public override PowerType Type =>
        PowerType.Buff;

    public override PowerStackType StackType =>
        PowerStackType.Counter;

    //Allows for more Grapple stacks to be applied based on player count
    public override bool ShouldScaleInMultiplayer => true;

    protected override IEnumerable<IHoverTip> ExtraHoverTips => new IHoverTip[]
    {
        HoverTipFactory.FromPower<GrappleFrogPower>()
    };
    
    public override string CustomPackedIconPath => "res://FrogKnight/images/powers/froggrapplingpower.png";
    public override string CustomBigIconPath => "res://FrogKnight/images/powers/froggrapplingpower.png";
    public override async Task AfterSideTurnStart(CombatSide side, IReadOnlyList<Creature> participants, ICombatState combatState)
    {
        if (!participants.Contains(base.Owner))
        {
            return;
        }
        Flash();
        await Cmd.CustomScaledWait(0.2f, 0.4f);
        await PowerCmd.Apply<GrappleFrogPower>(new ThrowingPlayerChoiceContext(), base.CombatState.HittableEnemies, base.Amount, base.Owner, null);
    }

    public override decimal GetScaledAmountForMultiplayer(ICombatState combatState, Creature? applier, decimal amount, Creature target,
        CardModel? cardSource)
    {
        return (Decimal) ((combatState.Players.Count - 1) * 2 + 1) * amount;
    }
}