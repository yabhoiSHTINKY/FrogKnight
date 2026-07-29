using FrogKnight.FrogKnightCode.Cards;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;

namespace FrogKnight.FrogKnightCode.Cards;


public class CheersFrog() : FrogKnightCard(1,
    CardType.Skill, CardRarity.Uncommon,
    TargetType.Self)
{
    public override string CustomPortraitPath => "res://FrogKnight/images/card_portraits/cheers.png";
    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[2]
{
        new CardsVar(1),
        new EnergyVar(2)
    };

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        await CreatureCmd.TriggerAnim(base.Owner.Creature, "Cast", base.Owner.Character.CastAnimDelay);
        await PlayerCmd.GainEnergy(base.DynamicVars.Energy.BaseValue, base.Owner);
        try
        {
            for (int _i = 0; _i < 1; _i++)
            {
                var token = ((CardModel)this).CombatState?.CreateCard<Dazed>(((CardModel)this).Owner);
                if (token != null)
                    CardCmd.PreviewCardPileAdd(await CardPileCmd.AddGeneratedCardToCombat(
                        (CardModel)(object)token, PileType.Draw, Owner, CardPilePosition.Random));
            }
        }
        catch (Exception ex)
        {
            Godot.GD.PrintErr($"[KnightlyBlow] Error in OnPlay: " + ex);
        }
    }

    protected override void OnUpgrade()
    {
    base.EnergyCost.UpgradeBy(-1);
    }
}