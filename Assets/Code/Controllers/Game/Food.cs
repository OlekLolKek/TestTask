using System;
using Code.Interfaces;
using Code.Interfaces.MonoBehaviourCycle;
using Code.Services;
using Code.Views.Game;
using UnityEngine;


namespace Code.Controllers.Game
{
    /// <summary>
    /// The logic controller for the Food objects.
    /// </summary>
    public sealed class Food : IGetId, IUpdatable, ICleanable
    {
        #region Events

        /// <summary>
        /// Called when the food view has finished playing particles and changed its position.
        /// </summary>
        public event Action Respawned;

        #endregion


        #region Properties

        public FoodView View { get; }
        public int ID { get; }
        public bool Respawning { get; private set; }

        #endregion


        #region Fields

        private readonly float _respawnTime;
        private readonly float _particleTime;

        private float _timer;
        private float _timeScale;

        #endregion


        #region CodeLife

        public Food(FoodView view, int id, float respawnTime, float particleTime)
        {
            View = view;
            ID = id;
            _respawnTime = respawnTime;
            _particleTime = particleTime;

            View.SetParentId(this);
            View.RequestRespawn += OnRequestRespawn;
        }

        public void Update(float deltaTime)
        {
            if (Respawning)
            {
                _timer -= deltaTime * _timeScale;

                if (_timer <= 0.0f)
                {
                    Respawn();
                }
            }
        }

        private void OnRequestRespawn()
        {
            _timer = _respawnTime;
            
            Respawning = true;

            View.PlayParticles();
        }

        private void Respawn()
        {
            Respawning = false;
            
            var newPosition = PositionPicker.Instance.PickRandomFoodPosition(ID);
            View.transform.position = newPosition;
            
            Respawned?.Invoke();
        }

        public void UpdateTimeScale(float newTimeScale)
        {
            _timeScale = newTimeScale;

            View.UpdateParticleTime(_particleTime / _timeScale);
        }

        public void Cleanup()
        {
            View.RequestRespawn -= OnRequestRespawn;
        }

        #endregion
    }
}