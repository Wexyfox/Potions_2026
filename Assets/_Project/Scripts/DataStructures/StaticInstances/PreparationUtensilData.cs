using UnityEngine;

namespace Potions2026.DataStructures
{
    [CreateAssetMenu(fileName = "PreparationUtensilData", menuName = "Data/PreparationUtensil")]
    public class PreparationUtensilData : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] [TextArea] private string _description;

        public string Name => _name;
        public string Description => _description;
    }
}