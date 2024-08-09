using Code.Data;
using UnityEngine.SceneManagement;


namespace Code.Controllers.Menu
{
    public sealed class SceneController
    {
        #region Fields

        private readonly SceneConfig _config;

        #endregion
        
        
        #region CodeLife

        public SceneController(SceneConfig config)
        {
            _config = config;
        }

        #endregion
        
        
        #region Methods

        public void LoadGameScene()
        {
            SceneManager.LoadScene(_config.GameSceneIndex);
        }

        #endregion
    }
}