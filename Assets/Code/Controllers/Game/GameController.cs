using Code.Data;
using Code.Models;
using UnityEngine;


namespace Code.Controllers.Game
{
    public sealed class GameController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GameConfig _config;
        [SerializeField] private Camera _camera;
        
        private readonly Controllers _controllers = new Controllers();

        #endregion


        #region Mono

        private void Start()
        {
            var animalsModel = new AnimalsModel(_config);

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
            _controllers.Dispose();
        }

        #endregion
    }
}