using Potions2026.DataStructures.Enums;
using System.Collections.Generic;
using UnityEngine;

namespace Potions2026.DataStructures
{
    /// <summary>
    /// FlavourProfile is responsible for accepting flavours and validating a query profile match.
    /// It is meant to be used as a class within a monobehaviour wrapper.
    /// </summary>
    [System.Serializable]
    public class FlavourProfile
    {
        [SerializeField] private Dictionary<FlavourType, int> _flavoursAdded;

        /// <summary>
        /// Flavours returns the flavour frequency dictionary.
        /// </summary>
        public Dictionary<FlavourType, int> Flavours => _flavoursAdded;

        /// <summary>
        /// Constructor
        /// </summary>
        public FlavourProfile()
        {
            _flavoursAdded = new Dictionary<FlavourType, int>();
        }

        /// <summary>
        /// Adds flavour to be tracked.
        /// </summary>
        /// <param name="flavour">Added flavour.</param>
        public void AddFlavour(FlavourType flavour)
        {
            if (_flavoursAdded.ContainsKey(flavour))
            {
                _flavoursAdded[flavour]++;
                return;
            }

            _flavoursAdded.Add(flavour, 0);
        }

        /// <summary>
        /// Checks if the added flavours meet the query flavour profile.
        /// Does not matter if there are more flavours present than the query profile.
        /// </summary>
        /// <param name="queryProfile">Flavour profile requirements.</param>
        /// <returns>If the added flavours meet the required frequencies of the query.</returns>
        public bool MeetsFlavourProfile(FlavourProfile queryProfile)
        {
            Dictionary<FlavourType, int> requiredFlavours = queryProfile.Flavours;
            foreach (KeyValuePair<FlavourType, int> requirement in requiredFlavours)
            {
                if (!_flavoursAdded.ContainsKey(requirement.Key))
                {
                    return false;
                }

                if (_flavoursAdded[requirement.Key] != requirement.Value)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
