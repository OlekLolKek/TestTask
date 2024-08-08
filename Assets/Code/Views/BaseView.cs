using Code.Interfaces;
using UnityEngine;


namespace Code.Views
{
    public class BaseView : MonoBehaviour, IActivatable
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