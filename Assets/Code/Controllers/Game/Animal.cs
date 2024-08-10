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


        #region CodeLife

        public Animal(AnimalView view, int id)
        {
            View = view;
            ID = id;

            View.TriggerEnter += OnTriggerEnter;
        }

        public void Cleanup()
        {
            View.TriggerEnter -= OnTriggerEnter;
        }

        #endregion


        #region Methods

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Constants.FOOD_TAG))
                return;

            if (!other.TryGetComponent(out FoodView foodView))
                return;

            if (foodView.ID != ID)
                return;
            
            
        }

        #endregion
    }
}