using FrogKnight.FrogKnightCode.Powers;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;

namespace FrogKnight.FrogKnightCode.Powers;


public class GrowingPowerFrogPower() : FrogKnightPower
{
    public override PowerType Type =>
        PowerType.Buff;

    public override PowerStackType StackType =>
        PowerStackType.Counter;
    
    public override string CustomPackedIconPath => "res://FrogKnight/images/powers/froggrowingpower.png";
    public override string CustomBigIconPath => "res://FrogKnight/images/powers/froggrowingpower.png";
    public override async Task AfterCardPlayed(PlayerChoiceContext choiceContext, CardPlay play)
    {
        if (play.Card.Owner?.Creature != base.Owner) return;
        try
        {
            Flash();
            await PowerCmd.Apply<MegaCrit.Sts2.Core.Models.Powers.VigorPower>(choiceContext,
                base.Owner, 2m,
                base.Owner, (CardModel?)null);
        }
        catch (Exception ex)
        {
            Godot.GD.PrintErr($"[{GetType().Name}] Error in afterCardPlayed: " + ex);
        }
    }
}