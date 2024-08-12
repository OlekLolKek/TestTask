using Code.Data;
using Code.Interfaces;
using Code.Interfaces.MonoBehaviourCycle;
using Code.Views.Game;
using UnityEngine;


namespace Code.Controllers.Game
{
    /// <summary>
    /// The logic controller for the Animal objects.
    /// </summary>
    public sealed class Animal : IGetId, ICleanable
    {
        #region Properties

        public int ID { get; }
        public AnimalView View { get; }

        #endregion


        #region Fields

        private readonly float _speed;
        private Food _assignedFood;

        #endregion


        #region CodeLife

        public Animal(AnimalView view, int id, float speed)
        {
            _speed = speed;
            View = view;
            ID = id;

            View.SetParentId(this);
            View.NavMeshAgent.speed = _speed;

            View.TriggerEnter += OnTriggerEnter;
        }

        public void Cleanup()
        {
            View.TriggerEnter -= OnTriggerEnter;

            if (_assignedFood.Respawning)
            {
                _assignedFood.Respawned -= OnFoodRespawned;
            }
        }

        #endregion


        #region Methods

        public void SetFood(Food food)
        {
            _assignedFood = food;

            UpdateDestination();
        }

        private void UpdateDestination()
        {
            View.NavMeshAgent.SetDestination(_assignedFood.View.transform.position);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Constants.FOOD_TAG))
                return;

            if (!other.TryGetComponent(out FoodView foodView))
                return;

            if (foodView.ID != ID)
                return;

            foodView.Respawn();

            _assignedFood.Respawned += OnFoodRespawned;
        }

        private void OnFoodRespawned()
        {
            _assignedFood.Respawned -= OnFoodRespawned;
            
            UpdateDestination();
        }

        public void UpdateTimeScale(float newTimeScale)
        {
            View.NavMeshAgent.speed = _speed * newTimeScale;

        }

        #endregion
    }
}