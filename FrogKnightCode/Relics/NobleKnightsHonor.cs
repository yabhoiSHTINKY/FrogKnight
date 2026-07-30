using FrogKnight.FrogKnightCode.Relics;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.Rooms;

namespace FrogKnight.FrogKnightCode.Relics;

public class NobleKnightsHonor() : FrogKnightRelic
{
    public override RelicRarity Rarity =>
        RelicRarity.Starter;

    public override string PackedIconPath => "res://FrogKnight/images/relics/NobleKnightsHonor.png";
    
    protected override string BigIconPath => "res://FrogKnight/images/relics/NobleKnightsHonor.png";

    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[] { new PowerVar<PlatingPower>(6m) };

    public override async Task AfterRoomEntered(AbstractRoom room)
    {
        if (room is CombatRoom)
        {
            Flash();
            await PowerCmd.Apply<PlatingPower>(new ThrowingPlayerChoiceContext(), base.Owner.Creature,
                base.DynamicVars["PlatingPower"].BaseValue, base.Owner.Creature, null);
        }
    }
}

