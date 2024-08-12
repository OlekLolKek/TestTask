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
        private readonly TimeModel _timeModel;

        private bool _initialized = false;

        #endregion


        #region CodeLife

        public FoodController(FoodModel model, AnimalsModel animalsModel, TimeModel timeModel)
        {
            _model = model;
            _animalsModel = animalsModel;
            _timeModel = timeModel;

            _animalsModel.AnimalsInitialized += OnAnimalsInitialized;
            _timeModel.TimeScaleChanged += OnTimeScaleChanged;
        }

        public void Cleanup()
        {
            _timeModel.TimeScaleChanged -= OnTimeScaleChanged;
            
            if (!_initialized)
            {
                _animalsModel.AnimalsInitialized -= OnAnimalsInitialized;
            }
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
            
            _model.InitializeFood(animals, _timeModel.TimeScale);
        }

        private void OnTimeScaleChanged(float newTimeScale)
        {
            foreach (var food in _model.Food)
            {
                food.UpdateTimeScale(newTimeScale);
            }
        }

        #endregion
    }
}