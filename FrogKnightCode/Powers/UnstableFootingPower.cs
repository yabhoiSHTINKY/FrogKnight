using BaseLib.Abstracts;
using FrogKnight.FrogKnightCode.Powers;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Models.Powers;

namespace FrogKnight.FrogKnightCode.Powers;


public class UnstableFootingPower() : CustomTemporaryPowerModel
{
    public override PowerType Type =>
        PowerType.Debuff;

    public override PowerStackType StackType =>
        PowerStackType.Counter;
    
    public override string CustomPackedIconPath => "res://FrogKnight/images/powers/unstablepower.png";
    public override string CustomBigIconPath => "res://FrogKnight/images/powers/unstablepower.png";

    public override AbstractModel OriginModel => ModelDb.Card<Anticipate>();
    protected override bool InvertInternalPowerAmount => true;
    public override PowerModel InternallyAppliedPower => ModelDb.Power<StrengthPower>();
    protected override Func<PlayerChoiceContext, Creature, decimal, Creature?, CardModel?, bool, Task> ApplyPowerFunc => PowerCmd.Apply<StrengthPower>;
}