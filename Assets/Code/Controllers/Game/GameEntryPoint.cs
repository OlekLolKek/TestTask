using Code.Data;
using Code.Models;
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
            var worldModel = new WorldModel();

            var worldController = new WorldController(_config, worldModel);
            var animalsController = new AnimalsController(animalsModel, worldModel);
            
            _controllers.AddController(worldController);
            _controllers.AddController(animalsController);
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