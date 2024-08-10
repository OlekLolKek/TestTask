namespace Code.Interfaces
{
    /// <summary>
    /// Used to activate or deactivate a certain class or GameObject.
    /// </summary>
    public interface IActivatable
    {
        bool IsActive { get; }
        
        /// <summary>
        /// Switches the active state to the specified one.
        /// </summary>
        /// <param name="active">Set to true if the entity should be activated. Set to false if the entity should be deactivated.</param>
        void SetActive(bool active);
    }
}