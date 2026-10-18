namespace Potions2026.MouseInteraction
{
    /// <summary>
    /// MouseInteractorArbiter is responsible for tracking which interactables and hoverables being acted on.
    /// Interactables take priority over hoverables as hoverables do not change the state of the game.
    /// It is intended to act as a cache gate and prevent simulateous inputs and hovers.
    /// </summary>
    public class MouseInteractorArbiter
    {
        private static MouseInteractorArbiter _instance = null;

        /// <summary>
        /// Constructor ensures internal values are null on creation.
        /// </summary>
        private MouseInteractorArbiter()
        {
            _currentHoverable = null;
            _currentInteractable = null;
        }

        public static MouseInteractorArbiter Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MouseInteractorArbiter();
                }
                return _instance;
            }
        }

        private IMouseHoverable _currentHoverable;
        private IMouseInteractable _currentInteractable;

        public bool Hoverable => _currentHoverable == null && _currentInteractable == null;
        public bool Interactable => _currentInteractable == null;

        /// <summary>
        /// Starts tracking a hoverable.
        /// </summary>
        /// <param name="hoverable">Hoverable for tracking.</param>
        public void StartTrackingHoverable(IMouseHoverable hoverable)
        {
            _currentHoverable = hoverable;
        }

        /// <summary>
        /// Stops tracking a hoverable. If the hoverable doesn't match cache, nothing occurs.
        /// </summary>
        /// <param name="hoverable">Hoverable to stop tracking.</param>
        public void StopTrackingHoverable(IMouseHoverable hoverable)
        {
            if (hoverable != _currentHoverable)
            {
                return;
            }
            _currentHoverable = null;
        }

        /// <summary>
        /// Starts tracking an interactable and automatically stops hovering if currently hovering.
        /// </summary>
        /// <param name="interactable">Interactable to start tracking</param>
        public void StartTrackingInteractable(IMouseInteractable interactable)
        {
            if (_currentHoverable != null)
            {
                StopTrackingHoverable(_currentHoverable);
            }
            _currentInteractable = interactable;
        }

        /// <summary>
        /// Stops tracking an interactable. If the interactable doesn't match cache, nothing occurs.
        /// </summary>
        /// <param name="interactable">Interactable to stop tracking.</param>
        public void StopTrackingInteractable(IMouseInteractable interactable)
        {
            if (interactable != _currentInteractable)
            {
                return;
            }
            _currentInteractable = null;
        }
    }
}
