using System.Collections.Generic;
using Code.Interfaces.MonoBehaviourCycle;
using Code.Models;


namespace Code.Controllers.Game
{
    public sealed class FoodController : ICleanable
    {
        #region Fields

        private readonly FoodModel _model;
        private readonly AnimalsModel _animalsModel;
        private readonly WorldModel _worldModel;

        private bool _initialized = false;

        #endregion


        #region CodeLife

        public FoodController(FoodModel model, AnimalsModel animalsModel, WorldModel worldModel)
        {
            _model = model;
            _animalsModel = animalsModel;
            _worldModel = worldModel;

            _animalsModel.AnimalsInitialized += OnAnimalsInitialized;
        }

        public void Cleanup()
        {
            if (!_initialized)
            {
                _animalsModel.AnimalsInitialized -= OnAnimalsInitialized;
            }
        }

        #endregion


        #region Methods

        private void OnAnimalsInitialized(HashSet<Animal> animals)
        {
            _initialized = true;
            _animalsModel.AnimalsInitialized -= OnAnimalsInitialized;
            
            _model.InitializeFood(animals, _worldModel.World);
        }

        #endregion
    }
}