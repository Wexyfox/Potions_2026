using Potions2026.DataStructures;
using Potions2026.DataStructures.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Potions2026.Cauldron
{
    /// <summary>
    /// CauldronEssenceTracker is responsible for accepting essences and returning a potion when queried.
    /// It is provided a list of valid potion recipes to allow for progression.
    /// It is meant to be used as a class within a monobehaviour wrapper.
    /// </summary>
    public class CauldronEssenceTracker
    {
        private Queue<IngredientEssenceType> _essencesAdded;
        private List<PotionRecipe> _validRecipes;

        /// <summary>
        /// Constructor with list of valid recipes it can create.
        /// </summary>
        /// <param name="validRecipes">List of valid recipes.</param>
        public CauldronEssenceTracker(List<PotionRecipe> validRecipes)
        {
            _essencesAdded = new Queue<IngredientEssenceType>();
            _validRecipes = validRecipes;
        }

        /// <summary>
        /// Adding essence for the cauldron to track.
        /// </summary>
        /// <param name="essence">Added essence.</param>
        public void AddEssence(IngredientEssenceType essence)
        {
            _essencesAdded.Enqueue(essence);
        }

        /// <summary>
        /// Checks all provided recipe requirements against tracked essences.
        /// Returns a valid recipe if able, otherwise returns null.
        /// </summary>
        /// <returns>A valid recipe, or a null one if unable.</returns>
        public PotionRecipe Brew()
        {
            IngredientEssenceType[] currentEssences = _essencesAdded.ToArray();
            foreach (PotionRecipe recipe in _validRecipes)
            {
                if (recipe.EssenceRequirements.SequenceEqual(currentEssences))
                {
                    return recipe;
                }
            }
            return null;
        }
    }
}
