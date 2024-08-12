using Code.Interfaces.MonoBehaviourCycle;
using Code.Models;
using UnityEngine.SceneManagement;


namespace Code.Controllers.Menu
{
    /// <summary>
    /// Controls the scene changes in the game.
    /// </summary>
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
        
        /// <summary>
        /// Load the scene with the specified build index.
        /// </summary>
        /// <param name="sceneIndex">The build index of the scene to load.</param>
        private void LoadSceneToIndex(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        #endregion
    }
}