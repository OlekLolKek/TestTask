namespace Code.Interfaces.MonoBehaviourCycle
{
    public interface IUpdatable : IController
    {
        void Update(float deltaTime);
    }
}