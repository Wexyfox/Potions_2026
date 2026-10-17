namespace Potions2026.Interaction
{
    /// <summary>
    /// IMouseInteractable is an interface for all interactable objects that are interacted by using the mouse.
    /// </summary>
    public interface IMouseInteractable
    {
        public bool ICanInteract();
        public void IInteract();
        public void IEndInteraction();
    }
}
