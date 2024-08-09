using System;
using UnityEngine;


namespace Code.Views.Game
{
    public sealed class AnimalView : BaseView
    {
        #region Events

        public event Action<Collider> TriggerEnter;

        #endregion


        #region Mono

        private void OnTriggerEnter(Collider other)
        {
            TriggerEnter?.Invoke(other);
        }

        #endregion
    }
}