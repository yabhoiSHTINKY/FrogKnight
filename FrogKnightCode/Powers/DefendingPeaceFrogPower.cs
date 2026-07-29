using FrogKnight.FrogKnightCode.Cards;
using FrogKnight.FrogKnightCode.Powers;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models.Powers;

namespace FrogKnight.FrogKnightCode.Powers;


public class DefendingPeaceFrogPower() : FrogKnightPower
{
    public override PowerType Type =>
        PowerType.Buff;

    public override PowerStackType StackType =>
        PowerStackType.Counter;
    
    public override string CustomPackedIconPath => "res://FrogKnight/images/powers/defendingpeaceFrogPower.png";
    public override string CustomBigIconPath => "res://FrogKnight/images/powers/defendingpeaceFrogPower.png";
    public override async Task AfterCardPlayed(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        if (cardPlay.Card is InnerPeace && cardPlay.Card.Owner.Creature == base.Owner)
        {
            Flash();
            await PowerCmd.Apply<PlatingPower>(new ThrowingPlayerChoiceContext(), base.Owner, base.Amount, base.Owner,
                null);
            await PowerCmd.Apply<VigorPower>(new ThrowingPlayerChoiceContext(), base.Owner, base.Amount, base.Owner,
                null);
        }

    }
}