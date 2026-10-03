namespace Potions2026.DataStructures.Enums
{
    /// <summary>
    /// Preperation actions are done to ingredients to draw out the essence within them.
    /// An ingredient can have multiple essences, but only have one drawn out based on preparation.
    /// An ingredient that is not prepared has no essence and is a dud ingredient.
    /// </summary>
    public enum PreparationActionType
    {
        NONE,
        CUTTING,
        GRATING,
        GRINDING,
        SQUEEZING,
        PULPING
    }
}
