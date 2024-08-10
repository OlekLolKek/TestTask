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

        private readonly GameConfig _config;
        private readonly WorldModel _model;

        #endregion


        #region CodeLife

        public WorldController(GameConfig config, WorldModel model)
        {
            _config = config;
            _model = model;
        }
        
        public void Start()
        {
            var worldFactory = new WorldFactory(_config);

            var world = worldFactory.Create();

            _model.SetWorld(world);
        }

        #endregion
    }
}