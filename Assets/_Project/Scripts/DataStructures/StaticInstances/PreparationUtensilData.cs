using UnityEngine;

namespace Potions2026.DataStructures
{
    /// <summary>
    /// PreparationUtensilData is responsible for holding static information about a preparation utensil.
    /// It has public functions for retrieving data about the utensil.
    /// </summary>
    [CreateAssetMenu(fileName = "PreparationUtensilData", menuName = "Data/PreparationUtensil")]
    public class PreparationUtensilData : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] [TextArea] private string _description;

        public string Name => _name;
        public string Description => _description;
    }
}