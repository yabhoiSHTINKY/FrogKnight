using FrogKnight.FrogKnightCode.Cards;
using FrogKnight.FrogKnightCode.Powers;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace FrogKnight.FrogKnightCode.Cards;

public class SpeedBugFrog() : FrogKnightCard(2,
    CardType.Power, CardRarity.Uncommon,
    TargetType.Self)
{
    public override string CustomPortraitPath => "res://FrogKnight/images/card_portraits/fasterbug.png";
    
    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[2]
    {
        new PowerVar<SpeedBugPower>(1m),
        new CardsVar(1)
    };

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
        {
            await CreatureCmd.TriggerAnim(base.Owner.Creature, "Cast", base.Owner.Character.CastAnimDelay);
            await PowerCmd.Apply<SpeedBugPower>(choiceContext, base.Owner.Creature, base.DynamicVars["SpeedBugPower"].BaseValue, base.Owner.Creature, this);
            await CardPileCmd.Draw(choiceContext, base.DynamicVars.Cards.BaseValue, base.Owner);
        }
     

    protected override void OnUpgrade()
    {
        base.EnergyCost.UpgradeBy(-1);
    }
}