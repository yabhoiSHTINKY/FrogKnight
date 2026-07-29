using BaseLib.Abstracts;
using BaseLib.Utils.NodeFactories;
using FrogKnight.FrogKnightCode.Cards;
using FrogKnight.FrogKnightCode.Extensions;
using FrogKnight.FrogKnightCode.Relics;
using Godot;
using MegaCrit.Sts2.Core.Animation;
using MegaCrit.Sts2.Core.Bindings.MegaSpine;
using MegaCrit.Sts2.Core.Entities.Characters;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Models.Relics;

namespace FrogKnight.FrogKnightCode.Character;

public class FrogKnight : PlaceholderCharacterModel
{
    public const string CharacterId = "FrogKnight";

    public static readonly Color Color = new("570861");

    public override Color NameColor => Color;
    public override CharacterGender Gender => CharacterGender.Masculine;
    public override int StartingHp => 85;
    public override int StartingGold => 60;

    public override IEnumerable<CardModel> StartingDeck =>
    [
        ModelDb.Card<StrikeFrogKnight>(),
        ModelDb.Card<StrikeFrogKnight>(),
        ModelDb.Card<StrikeFrogKnight>(),
        ModelDb.Card<WeakeningBlow>(),
        ModelDb.Card<DefendFrogKnight>(),
        ModelDb.Card<DefendFrogKnight>(),
        ModelDb.Card<DefendFrogKnight>(),
        ModelDb.Card<WellDefendedFrog>()
    ];

    public override IReadOnlyList<RelicModel> StartingRelics =>
    [
        ModelDb.Relic<KnightsHonor>()
    ];

    public override CardPoolModel CardPool => ModelDb.CardPool<FrogKnightCardPool>();
    public override RelicPoolModel RelicPool => ModelDb.RelicPool<FrogKnightRelicPool>();
    public override PotionPoolModel PotionPool => ModelDb.PotionPool<FrogKnightPotionPool>();

    /*  PlaceholderCharacterModel will utilize placeholder basegame assets for most of your character assets until you
        override all the other methods that define those assets.
        These are just some of the simplest assets, given some placeholders to differentiate your character with.
        You don't have to, but you're suggested to rename these images. */
    public override Control CustomIcon
    {
        get
        {
            var icon = NodeFactory<Control>.CreateFromResource(CustomIconTexturePath);
            icon.SetAnchorsAndOffsetsPreset(Control.LayoutPreset.FullRect);
            return icon;
        }
    }

    
    //public override string CustomIconTexturePath => "character_icon_char_name.png".CharacterUiPath();
    public override string CustomIconTexturePath => "res://FrogKnight/images/charui/character_icon_char_name.png";
    //public override string CustomCharacterSelectIconPath => "char_select_char_name.png".CharacterUiPath();
    public override string CustomCharacterSelectIconPath =>"res://FrogKnight/images/charui/char_select_char_name.png";
    //public override string CustomCharacterSelectLockedIconPath => "char_select_char_name_locked.png".CharacterUiPath();
    public override string CustomCharacterSelectLockedIconPath => "res://FrogKnight/images/charui/char_select_char_name_locked.png";
    //public override string CustomMapMarkerPath => "map_marker_char_name.png".CharacterUiPath();
    public override string CustomMapMarkerPath => "res://FrogKnight/images/charui/map_marker_char_name.png";
    //public override string CustomArmPaperTexturePath =>"frogknighthandpaper.png".CharacterUiPath();
    public override string CustomArmPaperTexturePath => "res://FrogKnight/images/charui/frogknighthandpaper.png";
    //public override string CustomArmPointingTexturePath =>"frogknighthandpoint.png".CharacterUiPath();
    public override string CustomArmPointingTexturePath => "res://FrogKnight/images/charui/frogknighthandpoint.png";
    //public override string CustomArmRockTexturePath => "frogknighthandrock.png".CharacterUiPath();
    public override string CustomArmRockTexturePath => "res://FrogKnight/images/charui/frogknighthandrock.png";
    //public override string CustomArmScissorsTexturePath => "frogknighthandscissors.png".CharacterUiPath();
    public override string CustomArmScissorsTexturePath => "res://FrogKnight/images/charui/frogknighthandscisors.png";
    //public override string CustomCharacterSelectBg => "frogknightcharacterbg.png".CharacterUiPath();
    public override string CustomCharacterSelectBg => "res://FrogKnight/images/character/bacground/frogbg2.tscn";
    public override Color MapDrawingColor => new Color("570861");
    public override string CustomVisualPath => "res://FrogKnight/images/character/FrogAnims3.tscn";
    public override string CustomEnergyCounterPath => "res://FrogKnight/images/energycounter/energycount2.tscn";
    public override string CustomMerchantAnimPath => "res://FrogKnight/images/character/frogshop.tscn";
    public override string CustomRestSiteAnimPath => "res://FrogKnight/images/restsite/frogsite.tscn";
}
