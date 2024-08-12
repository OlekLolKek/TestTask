using System;
using Code.Data;


namespace Code.Models
{
    /// <summary>
    /// Used to request scene changes from different parts of the game.
    /// </summary>
    public sealed class SceneChangeModel
    {
        #region Events
        
        /// <summary>
        /// Called when a different class calls a scene change request method.
        /// </summary>
        public event Action<int> ChangeSceneToIndexRequest;

        #endregion


        #region Fields

        private readonly SceneConfig _config;

        #endregion


        #region CodeLife

        public SceneChangeModel(SceneConfig config)
        {
            _config = config;
        }

        #endregion


        #region Methods

        /// <summary>
        /// Sends a request for the controller to switch the scene to Main Menu.
        /// </summary>
        public void RequestSceneChangeToMenu()
        {
            ChangeSceneToIndexRequest?.Invoke(_config.MainMenuSceneIndex);
        }
        
        /// <summary>
        /// Sends a request for the controller to switch the scene to Game scene.
        /// </summary>
        public void RequestSceneChangeToGame()
        {
            ChangeSceneToIndexRequest?.Invoke(_config.GameSceneIndex);
        }

        #endregion
    }
}