namespace Code.Interfaces.MonoBehaviourCycle
{
    /// <summary>
    /// Used to call the LateUpdate() method in a non-MonoBehaviour class.
    /// The deriving classes can be added to the Controllers class using the AddController() method.
    /// </summary>
    public interface ILateUpdatable : IController
    {
        /// <summary>
        /// Called when a LateUpdate() call happens in the entry point class.
        /// </summary>
        /// <param name="deltaTime">The Time.deltaTime value for the current frame.</param>
        void LateUpdate(float deltaTime);
    }
}