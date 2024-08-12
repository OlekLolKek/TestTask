using System;
using Code.Controllers.Game;
using Code.Interfaces;
using UnityEngine;


namespace Code.Views.Game
{
    public sealed class FoodView : BaseView, IGetId
    {
        #region Events

        /// <summary>
        /// Called when the owner animal touches the food and should "eat" it.
        /// </summary>
        public event Action RequestRespawn;

        #endregion
        
        
        #region Properties

        public int ID { get; private set; }

        #endregion


        #region Fields

        [SerializeField] private ParticleSystem _respawnParticles;

        #endregion


        #region Methods

        public void SetParentId(Food parent)
        {
            ID = parent.ID;
        }

        public void Respawn()
        {
            RequestRespawn?.Invoke();
        }

        public void PlayParticles()
        {
            _respawnParticles.Play();
        }

        #endregion
    }
}