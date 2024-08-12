using Code.Controllers.Game;
using Code.Data;
using Code.Views.Game;
using UnityEngine;


namespace Code.Factories
{
    /// <summary>
    /// Creates Food for the provided animal using the provided data.
    /// </summary>
    public sealed class FoodFactory
    {
        #region Fields

        private readonly GameConfig _gameConfig;
        private readonly FoodConfig _foodConfig;
        private readonly float _animalSpeed;
        
        private readonly Collider[] _colliderBuffer = new Collider[5];

        private const int MAX_SPAWN_TRIES = 20;

        #endregion
        
        
        #region CodeLife

        public FoodFactory(GameConfig gameConfig)
        {
            _gameConfig = gameConfig;
            _foodConfig = gameConfig.FoodConfig;
            _animalSpeed = gameConfig.AnimalSpeed;
        }

        #endregion


        #region Methods
        
        
        public Food Create(Animal ownerAnimal, WorldView worldView)
        {
            var spawnPosition = Vector3.zero;
            
            var minPosition = worldView.transform.position;
            minPosition.x -= _gameConfig.FieldSize * 0.5f;
            minPosition.z -= _gameConfig.FieldSize * 0.5f;
            
            var maxPosition = worldView.transform.position;
            maxPosition.x += _gameConfig.FieldSize * 0.5f;
            maxPosition.z += _gameConfig.FieldSize * 0.5f;
            
            for (var i = 0; i < MAX_SPAWN_TRIES; ++i)
            {
                Vector3 offset = Random.insideUnitCircle;
                (offset.y, offset.z) = (offset.z, offset.y);
                
                offset *= Random.Range(_foodConfig.MinDistanceInUnits, _foodConfig.MaxDistanceInSeconds * _animalSpeed);

                spawnPosition = ownerAnimal.View.transform.position + offset;

                if (CheckForNoCollisions(spawnPosition, minPosition, maxPosition, ownerAnimal.ID))
                {
                    break;
                }
            }

            ClearBuffer();

            var view = Object.Instantiate(_foodConfig.Prefab, spawnPosition, Quaternion.identity);

            return new Food(view, ownerAnimal.ID);
        }
        
        /// <summary>
        /// Used to check if the spawn position overlaps with existing food or the owner animal.
        /// </summary>
        /// <param name="spawnPosition">The position to check.</param>
        /// <param name="minPosition">A Vector3 containing the minimum X and Z coordinates for the food.</param>
        /// <param name="maxPosition">A Vector3 containing the maximum X and Z coordinates for the food.</param>
        /// <param name="ownerId">The ID of the owner animal for this food.</param>
        /// <returns>True, if there's no food around and the position is within the map.
        /// False, if the point is too close to existing food or the owner animal or the point is outside the map.</returns>
        private bool CheckForNoCollisions(Vector3 spawnPosition, Vector3 minPosition, Vector3 maxPosition, int ownerId)
        {
            if (spawnPosition.x < minPosition.x || spawnPosition.z < minPosition.z ||
                spawnPosition.x > maxPosition.x || spawnPosition.z > maxPosition.z)
            {
                return false;
            }

            var halfExtents = new Vector3(_foodConfig.FoodSize / 2, _foodConfig.FoodSize / 2, _foodConfig.FoodSize / 2);
            
            var overlappingFoodCount = Physics.OverlapBoxNonAlloc(spawnPosition, halfExtents, _colliderBuffer,
                Quaternion.identity, _foodConfig.FoodLayer);
            
            if (overlappingFoodCount <= 0)
            {
                return true;
            }
            
            foreach (var collider in _colliderBuffer)
            {
                if (collider == null) 
                    continue;
                
                if (collider.CompareTag(Constants.FOOD_TAG))
                {
                    return false;
                }

                if (collider.CompareTag(Constants.ANIMAL_TAG))
                {
                    if (collider.TryGetComponent(out AnimalView animalView))
                    {
                        if (animalView.ID == ownerId)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Clears the collider buffer for future usage
        /// </summary>
        private void ClearBuffer()
        {
            for (var i = 0; i < _colliderBuffer.Length; ++i)
            {
                _colliderBuffer[i] = null;
            }
        }

        #endregion
    }
}