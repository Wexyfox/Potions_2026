using Potions2026.DataStructures;

namespace Potions2026.Preparation
{
    /// <summary>
    /// IPreparationUtensilPair is an interface for marking classes as being a compound pair of utensils.
    /// It allows data from an instance to be passed.
    /// </summary>
    public interface IPreparationUtensilPair
    {
        public PreparationUtensilData PreparationUtensilData();
    }
}