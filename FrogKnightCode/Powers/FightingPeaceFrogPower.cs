using FrogKnight.FrogKnightCode.Cards;
using FrogKnight.FrogKnightCode.Powers;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.ValueProps;

namespace FrogKnight.FrogKnightCode.Powers;

public class FightingPeaceFrogPower() : FrogKnightPower
{
    public override PowerType Type =>
        PowerType.Buff;

    public override PowerStackType StackType =>
        PowerStackType.Counter;
    
    protected override IEnumerable<IHoverTip> ExtraHoverTips => new IHoverTip[]
    {
        HoverTipFactory.FromCard<InnerPeace>()
    };

    public override string CustomPackedIconPath => "res://FrogKnight/images/powers/fightingpeacepower.png";
    public override string CustomBigIconPath => "res://FrogKnight/images/powers/fightingpeacepower.png";
    public override async Task AfterCardPlayed(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        if (cardPlay.Card is InnerPeace && cardPlay.Card.Owner.Creature == base.Owner)
        {
            IReadOnlyList<Creature> hittableEnemies = base.CombatState.HittableEnemies;
            if (hittableEnemies.Count != 0)
            {
                Creature? item = base.Owner.Player?.RunState.Rng.CombatTargets.NextItem(hittableEnemies);
                await CreatureCmd.Damage(choiceContext, item ?? throw new InvalidOperationException(), base.Amount, ValueProp.Unblockable | ValueProp.Unpowered, null, null);
            }
        }
    }
    
}