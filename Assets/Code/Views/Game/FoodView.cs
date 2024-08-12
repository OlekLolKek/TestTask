using System;
using Code.Controllers.Game;
using Code.Interfaces;
using UnityEngine;


namespace Code.Views.Game
{
    public sealed class FoodView : BaseView, IGetId
    {
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

        public void PlayParticles()
        {
            _respawnParticles.Play();
        }

        public void UpdateParticleTime(float time)
        {
            if (_respawnParticles.isPlaying)
                _respawnParticles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            
            var main = _respawnParticles.main;
            main.startLifetime = time;
            main.duration = time;
        }

        #endregion
    }
}