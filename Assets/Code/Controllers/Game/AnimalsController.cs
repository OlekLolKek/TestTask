using Code.Interfaces.MonoBehaviourCycle;
using Code.Models;
using Code.Views.Game;


namespace Code.Controllers.Game
{
    /// <summary>
    /// Controls the behaviour of animals in the game
    /// </summary>
    public sealed class AnimalsController : IUpdatable, ICleanable
    {
        #region Fields

        private readonly AnimalsModel _model;
        private readonly WorldModel _worldModel;
        private readonly TimeModel _timeModel;

        private bool _initialized = false;

        #endregion
        
        
        #region CodeLife

        public AnimalsController(AnimalsModel model, WorldModel worldModel, TimeModel timeModel)
        {
            _model = model;
            _worldModel = worldModel;
            _timeModel = timeModel;

            _timeModel.TimeScaleChanged += UpdateTimeScale;
            _worldModel.WorldInitialized += OnWorldInitialized;
        }

        public void Cleanup()
        {
            _timeModel.TimeScaleChanged -= UpdateTimeScale;
            
            if (!_initialized)
            {
                _worldModel.WorldInitialized -= OnWorldInitialized;
            }
            
            _model.Cleanup();
        }

        #endregion


        #region Methods

        public void Update(float deltaTime)
        {
            foreach (var animalKvp in _model.Animals)
            {
                animalKvp.Value.Update(deltaTime);
            }
        }

        private void OnWorldInitialized(WorldView world)
        {
            _worldModel.WorldInitialized -= OnWorldInitialized;
            
            _model.InitializeAnimals();

            _initialized = true;
        }

        private void UpdateTimeScale(float newTimeScale)
        {
            foreach (var animalKvp in _model.Animals)
            {
                animalKvp.Value.UpdateTimeScale(newTimeScale);
            }
        }

        #endregion
    }
}