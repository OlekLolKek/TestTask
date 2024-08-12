using Code.Interfaces;


namespace Code.Views
{
    /// <summary>
    /// A view that can be activated or deactivated
    /// </summary>
    public class ActivatableView : BaseView, IActivatable
    {
        #region Properties

        public bool IsActive { get; private set; }

        #endregion
        
        
        #region Methods

        public virtual void SetActive(bool active)
        {
            IsActive = active;
            gameObject.SetActive(IsActive);
        }

        #endregion
    }
}