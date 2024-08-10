using System;
using UnityEngine;


namespace Code.Views.Game
{
    /// <summary>
    /// Assigned to the Animal prefab and GameObjects in the scene.
    /// </summary>
    public sealed class AnimalView : BaseView
    {
        #region Events

        /// <summary>
        /// Called when the animal enters a Trigger (usually food).
        /// </summary>
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