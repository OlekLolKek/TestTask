using System;
using Code.Data;


namespace Code.Models
{
    public sealed class SceneChangeModel
    {
        #region Events
        
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

        public void RequestSceneChangeToMenu()
        {
            ChangeSceneToIndexRequest?.Invoke(_config.MainMenuSceneIndex);
        }
        
        public void RequestSceneChangeToGame()
        {
            ChangeSceneToIndexRequest?.Invoke(_config.GameSceneIndex);
        }

        #endregion
    }
}