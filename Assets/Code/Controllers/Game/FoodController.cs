using System.Collections.Generic;
using Code.Interfaces.MonoBehaviourCycle;
using Code.Models;


namespace Code.Controllers.Game
{
    public sealed class FoodController : IUpdatable, ICleanable
    {
        #region Fields

        private readonly FoodModel _model;
        private readonly AnimalsModel _animalsModel;

        private bool _initialized = false;

        #endregion


        #region CodeLife

        public FoodController(FoodModel model, AnimalsModel animalsModel)
        {
            _model = model;
            _animalsModel = animalsModel;

            _animalsModel.AnimalsInitialized += OnAnimalsInitialized;
        }

        public void Cleanup()
        {
            if (!_initialized)
            {
                _animalsModel.AnimalsInitialized -= OnAnimalsInitialized;
            }
            
            _model.Cleanup();
        }

        #endregion


        #region Methods

        public void Update(float deltaTime)
        {
            foreach (var food in _model.Food)
            {
                food.Update(deltaTime);
            }
        }

        private void OnAnimalsInitialized(Dictionary<int, Animal> animals)
        {
            _initialized = true;
            _animalsModel.AnimalsInitialized -= OnAnimalsInitialized;
            
            _model.InitializeFood(animals);
        }

        #endregion
    }
}