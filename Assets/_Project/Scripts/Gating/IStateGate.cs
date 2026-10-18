namespace Potions2026.Gating
{
    /// <summary>
    /// IStateGate is an interface for forcing components to implement logic gating for their state or actions.
    /// </summary>
    public interface IStateGate
    {
        public bool GatingPassed();
    }
}