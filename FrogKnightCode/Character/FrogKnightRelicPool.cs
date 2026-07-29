using BaseLib.Abstracts;
using FrogKnight.FrogKnightCode.Extensions;
using Godot;

namespace FrogKnight.FrogKnightCode.Character;

public class FrogKnightRelicPool : CustomRelicPoolModel
{
    public override Color LabOutlineColor => FrogKnight.Color;

    public override string? BigEnergyIconPath => "res://FrogKnight/images/charui/card_orb.png";
    public override string TextEnergyIconPath => "charui/text_energy.png".ImagePath();
}