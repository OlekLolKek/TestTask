namespace Code.Interfaces
{
    public interface IActivatable
    {
        bool IsActive { get; }
        
        void SetActive(bool active);
    }
}