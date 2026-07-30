using FrogKnight.FrogKnightCode.Powers;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;

namespace FrogKnight.FrogKnightCode.Powers;


public class RecklessFrogPower() : FrogKnightPower
{
    public override PowerType Type =>
        PowerType.Buff;

    public override PowerStackType StackType =>
        PowerStackType.Counter;

    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[]
    {
        new EnergyVar(1)
    };

    protected override IEnumerable<IHoverTip> ExtraHoverTips => new IHoverTip[]
    {
        HoverTipFactory.ForEnergy((PowerModel) this)
    };

    public override string CustomPackedIconPath => "res://FrogKnight/images/powers/recklesspower.png";
    public override string CustomBigIconPath => "res://FrogKnight/images/powers/recklesspower.png";
    public override decimal ModifyMaxEnergy(Player player, decimal amount)
    {
        return player != this.Owner.Player ? amount : amount + (decimal) this.Amount;
    }
}