using Code.Data;
using Code.Views.Game;
using UnityEngine;


namespace Code.Factories
{
    /// <summary>
    /// Creates a world for the game with the size specified in the GameConfig.
    /// </summary>
    public sealed class WorldFactory
    {
        private readonly GameConfig _config;

        public WorldFactory(GameConfig config)
        {
            _config = config;
        }
        
        public WorldView Create()
        {
            var world = Object.Instantiate(_config.WorldPrefab);

            world.transform.localScale = new Vector3(_config.FieldSize, 1.0f, _config.FieldSize);
            world.BakeNavMesh();

            return world;
        }
    }
}