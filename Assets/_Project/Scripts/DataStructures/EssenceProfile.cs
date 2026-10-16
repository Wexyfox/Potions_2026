using Potions2026.DataStructures;
using Potions2026.DataStructures.Enums;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Potions2026.Cauldron
{
    /// <summary>
    /// EssenceProfile is responsible for accepting essences and returning a matching potion recipe when queried.
    /// It is meant to be used as a class within a monobehaviour wrapper.
    /// </summary>
    [System.Serializable]
    public class EssenceProfile
    {
        [SerializeField] private List<EssenceType> _essencesAdded;

        /// <summary>
        /// Constructor.
        /// </summary>
        public EssenceProfile()
        {
            _essencesAdded = new List<EssenceType>();
        }

        /// <summary>
        /// Adding essence to be track.
        /// </summary>
        /// <param name="essence">Added essence.</param>
        public void AddEssence(EssenceType essence)
        {
            _essencesAdded.Add(essence);
        }

        /// <summary>
        /// Checks all provided recipe requirements against tracked essences.
        /// Returns a valid recipe if able, otherwise returns null.
        /// </summary>
        /// /// <param name="validRecipes">Valid recipes.</param>
        /// <returns>A valid recipe, or a null one if unable.</returns>
        public PotionRecipe Brew(PotionRecipe[] validRecipes)
        {
            EssenceType[] currentEssences = _essencesAdded.ToArray();
            foreach (PotionRecipe recipe in validRecipes)
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
