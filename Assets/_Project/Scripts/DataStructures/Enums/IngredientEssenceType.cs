namespace Potions2026.DataStructures.Enums
{
    /// <summary>
    /// Essences are the building blocks of a potion.
    /// Combining multiple essences is how a recipe is formed.
    /// The specific ingredients of a potion is not important as it's effect is drawn from the essences within it.
    /// </summary>
    public enum IngredientEssenceType
    {
        INVALID,
        GROWTH,
        DECAY,
        FIRE,
        EARTH,
        AIR,
        WATER
    }
}
