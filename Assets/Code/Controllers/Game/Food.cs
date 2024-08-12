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
        
        private float _timer;

        #endregion


        #region CodeLife

        public Food(FoodView view, int id, float respawnTime)
        {
            View = view;
            ID = id;
            _respawnTime = respawnTime;

            View.SetParentId(this);
            View.RequestRespawn += OnRequestRespawn;
        }

        public void Update(float deltaTime)
        {
            if (Respawning)
            {
                _timer -= deltaTime;

                if (_timer <= 0.0f)
                {
                    Respawn();
                }
            }
        }

        private void OnRequestRespawn()
        {
            if (ID == 0)
            {
                Debug.Log($"Setting timer to {_respawnTime}");
            }
            
            _timer = _respawnTime;
            
            Respawning = true;

            View.PlayParticles();
        }

        private void Respawn()
        {
            if (ID == 0)
            {
                Debug.Log($"Respawning");
            }
            
            Respawning = false;
            
            var newPosition = PositionPicker.Instance.PickRandomFoodPosition(ID);
            View.transform.position = newPosition;
            
            Respawned?.Invoke();
        }

        public void Cleanup()
        {
            View.RequestRespawn -= OnRequestRespawn;
        }

        #endregion
    }
}