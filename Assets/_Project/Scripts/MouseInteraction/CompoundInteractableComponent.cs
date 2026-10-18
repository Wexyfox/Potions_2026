using AYellowpaper;
using Potions2026.Gating;
using System.Collections.Generic;
using UnityEngine;

namespace Potions2026.MouseInteraction
{
    /// <summary>
    /// CompoundInteractableComponent is responsible for using multiple interactables with a single entry point.
    /// Meant to be used to enable things such as game logic and sound effects at the same time.
    /// Has an optional IGatedComponent.
    /// </summary>

    [System.Serializable]
    public class CompoundInteractableComponent : IMouseInteractable
    {
        [Header("Hoverables")]
        [SerializeField] private List<InterfaceReference<IMouseInteractable>> _interactables;

        [Header("OPTIONAL")]
        [SerializeField] private InterfaceReference<IStateGate> _stateGate;

        /// <summary>
        /// Checks if there is a specific state gate that must be satisfied before deferring to interactables for interactable status.
        /// </summary>
        /// <returns>If the compound IMouseInteractable is hoverable.</returns>
        public bool ICanInteract()
        {
            if (_stateGate != null)
            {
                return _stateGate.Value.GatingPassed();
            }

            foreach (InterfaceReference<IMouseInteractable> interactables in _interactables)
            {
                if (!interactables.Value.ICanInteract())
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Starts interacting on all composition interactables.
        /// </summary>
        public void IStartInteracting()
        {
            foreach (InterfaceReference<IMouseInteractable> interactables in _interactables)
            {
                interactables.Value.IStartInteracting();
            }
        }

        /// <summary>
        /// Stops interacting on all composition interactables.
        /// </summary>
        public void IStopInteracting()
        {
            foreach (InterfaceReference<IMouseInteractable> interactables in _interactables)
            {
                interactables.Value.IStopInteracting();
            }
        }
    }
}