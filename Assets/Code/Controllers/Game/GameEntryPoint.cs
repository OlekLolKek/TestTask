using Code.Data;
using Code.Models;
using Code.Services;
using UnityEngine;


namespace Code.Controllers.Game
{
    /// <summary>
    /// Creates the main controllers and models. Calls the MonoBehaviour methods on the Controllers class.
    /// </summary>
    public sealed class GameEntryPoint : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GameConfig _config;
        [SerializeField] private Camera _camera;
        
        private readonly Controllers _controllers = new Controllers();

        #endregion


        #region Mono

        private void Awake()
        {
            var animalsModel = new AnimalsModel(_config);
            var worldModel = new WorldModel(_config);
            var foodModel = new FoodModel(_config);

            var worldController = new WorldController(worldModel);
            var animalsController = new AnimalsController(animalsModel, worldModel);
            var foodController = new FoodController(foodModel, animalsModel);

            var positionPicker = new PositionPicker(_config, worldModel, animalsModel);
            
            _controllers.AddController(worldController);
            _controllers.AddController(animalsController);
            _controllers.AddController(foodController);
            _controllers.AddController(positionPicker);
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