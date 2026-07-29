using FrogKnight.FrogKnightCode.Cards;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;

namespace FrogKnight.FrogKnightCode.Cards;

public class MakeHasteFrog() : FrogKnightCard(0,
    CardType.Skill, CardRarity.Common,
    TargetType.Self)
{
    public override string CustomPortraitPath => "res://FrogKnight/images/card_portraits/makehaste.png";
    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[2]
    {
        new EnergyVar(1),
        new PowerVar<PlatingPower>(-2)
    };

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
            await CreatureCmd.TriggerAnim(base.Owner.Creature, "Cast", base.Owner.Character.CastAnimDelay);
            if (base.Owner.Creature.GetPowerAmount<MegaCrit.Sts2.Core.Models.Powers.PlatingPower>() >= 2)
            {
                await PlayerCmd.GainEnergy(base.DynamicVars.Energy.BaseValue, base.Owner);
                await PowerCmd.Apply<PlatingPower>(choiceContext, base.Owner.Creature,
                    base.DynamicVars["PlatingPower"].BaseValue, base.Owner.Creature, this);
            }
        
    }

    protected override void OnUpgrade()
    {
    base.DynamicVars.Energy.UpgradeValueBy(1);
    }
}