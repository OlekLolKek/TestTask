using Code.Controllers.Game;
using Code.Data;
using Code.Services;
using UnityEngine;


namespace Code.Factories
{
    /// <summary>
    /// Creates Animals using the provided data.
    /// </summary>
    public sealed class AnimalFactory
    {
        /// <summary>
        /// Factory method that spawns an Animal specified in the config in a random position in the world.
        /// </summary>
        /// <param name="animalConfig">The AnimalConfig taken from the main GameConfig.</param>
        /// <param name="id">A unique identifier for the new animal</param>
        /// <returns>The Animal object for the spawned animal.</returns>
        public Animal Create(AnimalConfig animalConfig, int id)
        {
            var view = Object.Instantiate(animalConfig.AnimalPrefab, PositionPicker.Instance.PickRandomAnimalPosition(), Quaternion.identity);

            return new Animal(view, id, animalConfig.AnimalSpeed);
        }
    }
}