namespace Code.Interfaces.MonoBehaviourCycle
{
    /// <summary>
    /// Used to call the FixedUpdate method in a non-MonoBehaviour class.
    /// The deriving classes can be added to the Controllers class using the AddController() method.
    /// </summary>
    public interface IFixedUpdatable : IController
    {
        /// <summary>
        /// Called when a FixedUpdate call happens in the entry point class.
        /// </summary>
        /// <param name="fixedDeltaTime">The Time.fixedDeltaTime value for the current physics update frame.</param>
        void FixedUpdate(float fixedDeltaTime);
    }
}