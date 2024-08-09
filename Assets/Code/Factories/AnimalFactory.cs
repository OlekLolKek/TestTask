using Code.Data;
using Code.Views.Game;
using UnityEngine;


namespace Code.Factories
{
    public sealed class AnimalFactory
    {
        public AnimalView Create(GameConfig config, GameObject world)
        {
            var worldPosition = world.transform.position;
            var offsetX = Random.Range(-config.FieldSize / 2, config.FieldSize / 2);
            var offsetZ = Random.Range(-config.FieldSize / 2, config.FieldSize / 2);

            var offset = new Vector3(offsetX, 0.0f, offsetZ);
            offset.y = world.transform.localScale.y;

            return Object.Instantiate(config.AnimalPrefab, worldPosition + offset, Quaternion.identity);
        }
    }
}