namespace Potions2026.MouseInteraction
{
    /// <summary>
    /// IMouseHoverable is an interface for all hoverable objects that are hovered by using the mouse.
    /// </summary>
    public interface IMouseHoverable
    {
        public bool ICanHover();
        public void IHover();
        public void IEndHovering();
    }
}
