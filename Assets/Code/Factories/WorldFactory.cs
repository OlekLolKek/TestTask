using Code.Data;
using Code.Views.Game;
using UnityEngine;


namespace Code.Factories
{
    /// <summary>
    /// Creates a world for the game with the size specified in the GameConfig.
    /// Bakes the NavMesh surface after the world is created
    /// </summary>
    public sealed class WorldFactory
    {
        private readonly GameConfig _config;

        public WorldFactory(GameConfig config)
        {
            _config = config;
        }
        
        /// <summary>
        /// Creates a world for the game with the size specified in the GameConfig.
        /// Bakes the NavMesh surface after the world is created
        /// </summary>
        /// <returns>The WorldView component of the createc object.</returns>
        public WorldView Create()
        {
            var world = Object.Instantiate(_config.WorldConfig.WorldPrefab);

            world.transform.localScale = new Vector3(_config.WorldConfig.FieldSize, 1.0f, _config.WorldConfig.FieldSize);
            world.BakeNavMesh();

            return world;
        }
    }
}