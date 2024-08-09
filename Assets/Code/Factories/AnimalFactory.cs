using Code.Data;
using Code.Views.Game;
using UnityEngine;


namespace Code.Factories
{
    public sealed class AnimalFactory
    {
        /// <summary>
        /// Factory method that spawns an Animal specified in the config in a random position in the world.
        /// </summary>
        /// <param name="config">The GameConfig with spawn information.</param>
        /// <param name="world">The World GameObject to spawn the animals on to.</param>
        /// <returns>The AnimalView of the spawned animal.</returns>
        public AnimalView Create(GameConfig config, GameObject world)
        {
            var worldPosition = world.transform.position;
            var offsetX = Random.Range(-config.FieldSize / 2, config.FieldSize / 2);
            var offsetZ = Random.Range(-config.FieldSize / 2, config.FieldSize / 2);

            var offset = new Vector3(offsetX, config.AnimalSpawnHeight, offsetZ);

            return Object.Instantiate(config.AnimalPrefab, worldPosition + offset, Quaternion.identity);
        }
    }
}