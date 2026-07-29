using FrogKnight.FrogKnightCode.Powers;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Powers;

namespace FrogKnight.FrogKnightCode.Powers;


public class RecklessFrogPower() : FrogKnightPower
{
    public override PowerType Type =>
        PowerType.Buff;

    public override PowerStackType StackType =>
        PowerStackType.Counter;
    
    public override string CustomPackedIconPath => "res://FrogKnight/images/powers/recklesspower.png";
    public override string CustomBigIconPath => "res://FrogKnight/images/powers/recklesspower.png";
    public override decimal ModifyMaxEnergy(Player player, decimal amount)
    {
        if (player != base.Owner.Player)
        {
            return amount;
        }
        return amount + (decimal)base.Amount;
    }
}