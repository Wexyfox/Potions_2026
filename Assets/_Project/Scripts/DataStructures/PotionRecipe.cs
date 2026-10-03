using Potions2026.DataStructures.Enums;
using System.Linq;
using UnityEngine;

namespace Potions2026.DataStructures
{
    /// <summary>
    /// PotionRecipe is responsible for holding static information about a potion.
    /// </summary>
    [CreateAssetMenu(fileName = "PotionRecipe", menuName = "Data/PotionRecipe")]
    public class PotionRecipe : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private IngredientEssenceType[] _essenceRequirements;

        public string Name => _name;
        public string Description => _description;
        public bool MatchesEssenceRequirements(IngredientEssenceType[] essences) => _essenceRequirements.SequenceEqual(essences);
        public IngredientEssenceType[] EssenceRequirements => _essenceRequirements;
    }
}
