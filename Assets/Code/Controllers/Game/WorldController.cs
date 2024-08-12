using Code.Data;
using Code.Factories;
using Code.Interfaces.MonoBehaviourCycle;
using Code.Models;


namespace Code.Controllers.Game
{
    /// <summary>
    /// Controls the world's creation.
    /// </summary>
    public sealed class WorldController : IStartable
    {
        #region Fields
        
        private readonly WorldModel _model;

        #endregion


        #region CodeLife

        public WorldController(WorldModel model)
        {
            _model = model;
        }
        
        public void Start()
        {
            _model.InitializeWorld();
        }

        #endregion
    }
}