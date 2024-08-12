namespace Code.Interfaces.MonoBehaviourCycle
{
    /// <summary>
    /// Adds the Cleanup method to the derived class. Used to clean up data, dispose resources enc.
    /// The deriving classes can be added to the Controllers class using the AddController() method.
    /// </summary>
    public interface ICleanable : IController
    {
        /// <summary>
        /// Used to clean up data, dispose resources etc. Usually called when OnDestroy() is called in the entry point class.
        /// </summary>
        void Cleanup();
    }
}