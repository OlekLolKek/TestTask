using Code.Data;
using UnityEngine;


namespace Code.Factories
{
    public sealed class WorldFactory
    {
        private readonly GameConfig _config;

        public WorldFactory(GameConfig config)
        {
            _config = config;
        }
        
        public GameObject Create()
        {
            var level = Object.Instantiate(_config.WorldPrefab);

            level.transform.localScale = new Vector3(_config.FieldSize, 1.0f, _config.FieldSize);

            return level;
        }
    }
}