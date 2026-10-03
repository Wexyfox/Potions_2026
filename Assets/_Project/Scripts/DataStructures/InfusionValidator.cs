using Potions2026.DataStructures.Enums;
using System.Collections.Generic;

namespace Potions2026.DataStructures
{
    /// <summary>
    /// InfusionValidator is a static lookup responsible for determining if a preparation action is valid.
    /// </summary>
    public static class InfusionValidator
    {
        private static Dictionary<PreparationActionType, InfusionActionType> _infusionLookup
            = new Dictionary<PreparationActionType, InfusionActionType>()
            {
                { PreparationActionType.CUTTING , InfusionActionType.STRAINING },
                { PreparationActionType.GRATING , InfusionActionType.BOILING },
                { PreparationActionType.GRINDING , InfusionActionType.STIRRING },
                { PreparationActionType.SQUEEZING , InfusionActionType.SKIMMING },
                { PreparationActionType.PULPING , InfusionActionType.WHISKING }
            };

        /// <summary>
        /// Checks the infusion lookup dictionary <PreparationActionType, InfusionActionType> for validity.
        /// </summary>
        /// <param name="preperationAction">The preparation type of the ingredient.</param>
        /// <param name="infusionAction">The infusing action used after the ingredient was added.</param>
        /// <returns>Bool for if the PreparationActionType key and InfusionActionType value are a valid pair</returns>
        public static bool Validate(PreparationActionType preperationAction, InfusionActionType infusionAction)
        {
            return _infusionLookup[preperationAction] == infusionAction;
        }
    }
}
