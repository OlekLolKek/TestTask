namespace Code.Interfaces.MonoBehaviourCycle
{
    public interface IFixedUpdatable : IController
    {
        void FixedUpdate(float fixedDeltaTime);
    }
}