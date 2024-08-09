using Code.Interfaces.MonoBehaviourCycle;
using Code.Models;
using UnityEngine.SceneManagement;


namespace Code.Controllers.Menu
{
    public sealed class SceneController : ICleanable
    {
        #region Fields

        private readonly SceneChangeModel _model;

        #endregion
        
        
        #region CodeLife

        public SceneController(SceneChangeModel model)
        {
            _model = model;

            _model.ChangeSceneToIndexRequest += LoadSceneToIndex;
        }

        public void Cleanup()
        {
            _model.ChangeSceneToIndexRequest -= LoadSceneToIndex;
        }

        #endregion


        #region Methods

        private void LoadSceneToIndex(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        #endregion
    }
}