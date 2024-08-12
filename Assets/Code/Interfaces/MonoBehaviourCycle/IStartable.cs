namespace Code.Interfaces.MonoBehaviourCycle
{
    /// <summary>
    /// Used to call the Start() method in a non-MonoBehaviour class.
    /// The deriving classes can be added to the Controllers class using the AddController() method.
    /// </summary>
    public interface IStartable : IController
    {
        /// <summary>
        /// Called when a Start() call happens in the entry point class.
        /// </summary>
        void Start();
    }
}