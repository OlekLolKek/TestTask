using Code.Controllers.Game;
using Code.Data;
using Code.Services;
using UnityEngine;


namespace Code.Factories
{
    /// <summary>
    /// Creates Food for the provided animal using the provided data.
    /// </summary>
    public sealed class FoodFactory
    {
        #region Fields
        
        private readonly FoodConfig _foodConfig;

        #endregion
        
        
        #region CodeLife

        public FoodFactory(GameConfig gameConfig)
        {
            _foodConfig = gameConfig.FoodConfig;
        }

        #endregion


        #region Methods
        
        /// <summary>
        /// Creates a new Food object and spawns its view in a random spot on the map.
        /// </summary>
        /// <param name="ownerAnimal">The owner animal of the food.</param>
        /// <param name="timeScale">The starting timescale for the food.</param>
        /// <returns>The created Food object.</returns>
        public Food Create(Animal ownerAnimal, float timeScale)
        {
            var spawnPosition = PositionPicker.Instance.PickRandomFoodPosition(ownerAnimal.ID);

            var view = Object.Instantiate(_foodConfig.Prefab, spawnPosition, Quaternion.identity);

            return new Food(view, ownerAnimal.ID, _foodConfig.RespawnTime, _foodConfig.BaseParticleTime, timeScale);
        }

        #endregion
    }
}