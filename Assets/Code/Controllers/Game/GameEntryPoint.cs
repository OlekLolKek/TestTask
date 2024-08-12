using Code.Data;
using Code.Models;
using Code.Services;
using Code.Views.Game;
using UnityEngine;


namespace Code.Controllers.Game
{
    /// <summary>
    /// Creates the main controllers and models. Calls the MonoBehaviour methods on the Controllers class.
    /// </summary>
    public sealed class GameEntryPoint : MonoBehaviour
    {
        #region Fields

        [SerializeField] private TimeControlView _timeControlView;
        [SerializeField] private GameConfig _config;
        [SerializeField] private Camera _camera;
        
        private readonly Controllers _controllers = new();

        #endregion


        #region Mono

        private void Awake()
        {
            var animalsModel = new AnimalsModel(_config);
            var worldModel = new WorldModel(_config);
            var foodModel = new FoodModel(_config);
            var timeModel = new TimeModel();

            var worldController = new WorldController(worldModel);
            var animalsController = new AnimalsController(animalsModel, worldModel, timeModel);
            var foodController = new FoodController(foodModel, animalsModel, timeModel);
            var timeController = new TimeController(_timeControlView, timeModel);

            var positionPicker = new PositionPicker(_config, animalsModel, timeModel);
            
            _controllers.AddController(worldController);
            _controllers.AddController(animalsController);
            _controllers.AddController(foodController);
            _controllers.AddController(timeController);
        }

        private void Start()
        {
            _controllers.Start();
        }

        private void FixedUpdate()
        {
            _controllers.FixedUpdate(Time.fixedDeltaTime);
        }

        private void Update()
        {
            _controllers.Update(Time.deltaTime);
        }

        private void LateUpdate()
        {
            _controllers.LateUpdate(Time.deltaTime);
        }

        private void OnDestroy()
        {
            _controllers.Cleanup();
        }

        #endregion
    }
}