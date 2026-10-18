using AYellowpaper;
using Potions2026.Gating;
using System.Collections.Generic;
using UnityEngine;

namespace Potions2026.MouseInteraction
{
    /// <summary>
    /// CompoundHoverable is responsible for using multiple hoverables with a single entry point.
    /// Meant to be used to enable things such as outlines and particle effects at the same time.
    /// Has an optional IGatedComponent 
    /// </summary>
    public class CompoundHoverable : MonoBehaviour, IMouseHoverable
    {
        [Header("Hoverables")]
        [SerializeField] private List<InterfaceReference<IMouseHoverable>> _hoverables;

        [Header("OPTIONAL")]
        [SerializeField] private InterfaceReference<IStateGate> _stateGate;

        /// <summary>
        /// Checks if there is a specific state gate that must be satisfied before deferring to hoverables for hoverable status.
        /// </summary>
        /// <returns>If the compound IMouseHoverable is hoverable.</returns>
        public bool ICanHover()
        {
            if (_stateGate != null)
            {
                return _stateGate.Value.GatingPassed();
            }

            foreach (InterfaceReference<IMouseHoverable> hoverable in _hoverables)
            {
                if (!hoverable.Value.ICanHover())
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Starts hovering on all composition hoverables.
        /// </summary>
        public void IStartHovering()
        {
            foreach (InterfaceReference<IMouseHoverable> hoverable in _hoverables)
            {
                hoverable.Value.IStartHovering();
            }
        }

        /// <summary>
        /// Ends hovering on all composition hoverables.
        /// </summary>
        public void IEndHovering()
        {
            foreach (InterfaceReference<IMouseHoverable> hoverable in _hoverables)
            {
                hoverable.Value.IEndHovering();
            }
        }
    }
}