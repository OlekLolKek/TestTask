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
        
        
        public Food Create(Animal ownerAnimal)
        {
            var spawnPosition = PositionPicker.Instance.PickRandomFoodPosition(ownerAnimal.ID);

            var view = Object.Instantiate(_foodConfig.Prefab, spawnPosition, Quaternion.identity);

            return new Food(view, ownerAnimal.ID, _foodConfig.RespawnTime, _foodConfig.BaseParticleTime);
        }

        #endregion
    }
}