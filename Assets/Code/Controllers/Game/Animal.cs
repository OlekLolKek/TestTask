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
    public sealed class Animal : IGetId, IUpdatable, ICleanable
    {
        #region Properties

        public int ID { get; }
        public AnimalView View { get; }

        #endregion


        #region Fields

        private readonly float _speed;
        private Food _assignedFood;

        private const float DISTANCE_THRESHOLD = 0.5f;

        #endregion


        #region CodeLife

        public Animal(AnimalView view, int id, float speed)
        {
            _speed = speed;
            View = view;
            ID = id;

            View.SetParentId(this);
            View.NavMeshAgent.speed = _speed;
        }

        public void Cleanup()
        {
            if (_assignedFood.Respawning)
            {
                _assignedFood.Respawned -= OnFoodRespawned;
            }
        }

        #endregion


        #region Methods

        /// <summary>
        /// Used to assign the Food object after it's created
        /// </summary>
        /// <param name="food">The Food object to assign</param>
        public void SetFood(Food food)
        {
            _assignedFood = food;

            UpdateDestination();
        }

        private void UpdateDestination()
        {
            View.NavMeshAgent.SetDestination(_assignedFood.View.transform.position);
        }

        public void Update(float deltaTime)
        {
            if (_assignedFood.Respawning)
                return;
            
            if ((View.transform.position - _assignedFood.View.transform.position).sqrMagnitude <= DISTANCE_THRESHOLD)
            {
                _assignedFood.StartRespawn();
                
                _assignedFood.Respawned += OnFoodRespawned;
            }
        }

        private void OnFoodRespawned()
        {
            _assignedFood.Respawned -= OnFoodRespawned;
            
            UpdateDestination();
        }

        /// <summary>
        /// Used to update the TimeScale when it's changed in TimeModel.
        /// </summary>
        /// <param name="newTimeScale">The new timescale value.</param>
        public void UpdateTimeScale(float newTimeScale)
        {
            View.NavMeshAgent.speed = _speed * newTimeScale;
        }

        #endregion
    }
}