using Code.Interfaces.MonoBehaviourCycle;
using Code.Models;
using Code.Views.Game;


namespace Code.Controllers.Game
{
    public sealed class AnimalsController : ICleanable
    {
        #region Fields

        private readonly AnimalsModel _model;
        private readonly WorldModel _worldModel;

        private bool _initialized = false;

        #endregion
        
        
        #region CodeLife

        public AnimalsController(AnimalsModel model, WorldModel worldModel)
        {
            _model = model;
            _worldModel = worldModel;

            _worldModel.WorldInitialized += OnWorldInitialized;
        }

        public void Cleanup()
        {
            if (!_initialized)
            {
                _worldModel.WorldInitialized -= OnWorldInitialized;
            }
        }

        #endregion


        #region Methods

        private void OnWorldInitialized(WorldView world)
        {
            _worldModel.WorldInitialized -= OnWorldInitialized;
            
            _model.InitializeAnimals(world);

            _initialized = true;
        }

        #endregion
    }
}