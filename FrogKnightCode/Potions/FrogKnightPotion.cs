using BaseLib.Abstracts;
using BaseLib.Utils;
using FrogKnight.FrogKnightCode.Character;

namespace FrogKnight.FrogKnightCode.Potions;

[Pool(typeof(FrogKnightPotionPool))]
public abstract class FrogKnightPotion : CustomPotionModel;