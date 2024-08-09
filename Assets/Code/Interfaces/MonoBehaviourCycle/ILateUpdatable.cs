namespace Code.Interfaces.MonoBehaviourCycle
{
    public interface ILateUpdatable : IController
    {
        void LateUpdate(float deltaTime);
    }
}