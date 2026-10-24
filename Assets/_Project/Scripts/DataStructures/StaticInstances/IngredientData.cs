using AYellowpaper.SerializedCollections;
using Potions2026.DataStructures.Enums;
using UnityEngine;

namespace Potions2026.DataStructures
{
    /// <summary>
    /// IngredientData is responsible for holding static information about an ingredient.
    /// It has public functions for retrieving data about the ingredient and it's essences.
    /// </summary>
    [CreateAssetMenu(fileName = "IngredientData", menuName = "Data/Ingredient")]
    public class IngredientData : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] [TextArea] private string _description;
        [SerializeField] private FlavourType _flavourProfile;
        [SerializeField] private SerializedDictionary<PreparationActionType, EssenceType> _essenceLookup;

        public string Name => _name;
        public string Description => _description;
        public FlavourType FlavourProfile => _flavourProfile;
        public bool IsValidPreparation(PreparationActionType peparationAction) => _essenceLookup.ContainsKey(peparationAction);
        public EssenceType EssenceFromPreparation(PreparationActionType peparationAction)
        {
            if (peparationAction == PreparationActionType.NONE)
            {
                return EssenceType.INVALID;
            }

            if (!_essenceLookup.ContainsKey(peparationAction))
            {
                return EssenceType.INVALID;
            }

            return _essenceLookup[peparationAction];
        }
        public bool HasEssences => _essenceLookup.Count > 0;
    }
}
