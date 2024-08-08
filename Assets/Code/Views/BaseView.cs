using Code.Interfaces;
using UnityEngine;


namespace Code.Views
{
    public class BaseView : MonoBehaviour, IActivatableView
    {
        public virtual void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}