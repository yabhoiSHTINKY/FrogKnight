using FrogKnight.FrogKnightCode.Cards;
using MegaCrit.Sts2.Core.CardSelection;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;

namespace FrogKnight.FrogKnightCode.Cards;

public class AndAgainfrog() : FrogKnightCard(0,
	CardType.Attack, CardRarity.Uncommon,
	TargetType.AnyEnemy)
{
	public override string CustomPortraitPath => "res://FrogKnight/images/card_portraits/andagain.png";
	public override IEnumerable<CardKeyword> CanonicalKeywords => new CardKeyword[]
	{
		CardKeyword.Exhaust
	};
	protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[2]
	{
		new DamageVar(3m, ValueProp.Move),
		new CardsVar(1)
	};

	protected override async Task OnPlay(
		PlayerChoiceContext choiceContext,
		CardPlay play)
	{
		await DamageCmd.Attack(base.DynamicVars.Damage.BaseValue)
			.FromCard(this).Targeting(play.Target ?? throw new InvalidOperationException())
			.WithHitFx("vfx/vfx_attack_slash", null, "blunt_attack.mp3")
			.Execute(choiceContext);
		await CardPileCmd.Draw(choiceContext, DynamicVars.Cards.BaseValue, Owner);
	}

	protected override void OnUpgrade()
	{ 
		base.DynamicVars.Damage.UpgradeValueBy(2m);
	}
}
