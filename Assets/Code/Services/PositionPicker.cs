using Code.Controllers.Game;
using Code.Data;
using Code.Interfaces.MonoBehaviourCycle;
using Code.Models;
using Code.Views.Game;
using UnityEngine;


namespace Code.Services
{
    /// <summary>
    /// A singleton class used to pick random position for various in-game objects
    /// </summary>
    public sealed class PositionPicker
    {
        #region Properties

        public static PositionPicker Instance { get; private set; }

        #endregion


        #region Fields

        private readonly AnimalConfig _animalConfig;
        private readonly WorldConfig _worldConfig;
        private readonly FoodConfig _foodConfig;
        private readonly AnimalsModel _animalsModel;
        private readonly TimeModel _timeModel;

        private readonly Collider[] _colliderBuffer = new Collider[3];

        private Vector3 _minSpawnPosition;
        private Vector3 _maxSpawnPosition;

        private const int MAX_FIND_POSITION_TRIES = 20;

        #endregion


        #region CodeLife

        public PositionPicker(GameConfig config, AnimalsModel animalsModel, TimeModel timeModel)
        {
            _animalConfig = config.AnimalConfig;
            _worldConfig = config.WorldConfig;
            _foodConfig = config.FoodConfig;
            _animalsModel = animalsModel;
            _timeModel = timeModel;

            Instance = this;

            CalculateMinMaxPositions(config.WorldConfig.WorldSpawnPosition);
        }

        #endregion


        #region Methods

        private void CalculateMinMaxPositions(Vector3 worldPosition)
        {
            _minSpawnPosition = worldPosition;
            _minSpawnPosition.x -= _worldConfig.FieldSize * 0.5f;
            _minSpawnPosition.z -= _worldConfig.FieldSize * 0.5f;
            
            _maxSpawnPosition = worldPosition;
            _maxSpawnPosition.x += _worldConfig.FieldSize * 0.5f;
            _maxSpawnPosition.z += _worldConfig.FieldSize * 0.5f;
        }

        /// <summary>
        /// Finds and returns a random position for a food piece without overlapping other food pieces, its owner animal or the edge of the map.
        /// </summary>
        /// <returns>A new position for the food.</returns>
        public Vector3 PickRandomFoodPosition(int ownerId)
        {
            var spawnPosition = Vector3.zero;

            var ownerAnimal = _animalsModel.GetAnimalByID(ownerId);
            var animalPosition = ownerAnimal != null ? ownerAnimal.View.transform.position : Vector3.zero;
            
            for (var i = 0; i < MAX_FIND_POSITION_TRIES; ++i)
            {
                Vector3 offset = Random.insideUnitCircle;
                (offset.y, offset.z) = (offset.z, offset.y);

                var maxDistance = Mathf.Min(_worldConfig.FieldSize,
                    _foodConfig.MaxDistanceInSeconds * _animalConfig.AnimalSpeed * _timeModel.TimeScale);
                
                offset *= Random.Range(_foodConfig.MinDistanceInUnits, maxDistance);
                
                spawnPosition = animalPosition + offset;

                if (CheckForNoFoodCollisions(spawnPosition, ownerId))
                {
                    break;
                }
            }

            ClearBuffer();

            return spawnPosition;
        }
        
        /// <summary>
        /// Used to check if the spawn position overlaps with existing food or the owner animal, or is outside the map.
        /// </summary>
        /// <param name="spawnPosition">The position to check.</param>
        /// <param name="ownerId">The ID of the owner animal for this food.</param>
        /// <returns>True, if there's no food around and the position is within the map.
        /// False, if the position is too close to existing food or the owner animal or the position is outside the map.</returns>
        private bool CheckForNoFoodCollisions(Vector3 spawnPosition, int ownerId)
        {
            if (!CheckMinMaxPosition(spawnPosition)) return false;

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
        /// Used to check if the spawn position overlaps with existing animals or is outside the map.
        /// </summary>
        /// <param name="spawnPosition">The position to check.</param>
        /// <returns>True, if there's no animals around and the position is within the map.
        /// False, if the position is too close to existing animals or the position is outside the map.</returns>
        private bool CheckForNoAnimalCollisions(Vector3 spawnPosition)
        {
            if (!CheckMinMaxPosition(spawnPosition)) return false;
            
            var halfExtents = new Vector3(_animalConfig.AnimalSize / 2, _animalConfig.AnimalSize / 2, _animalConfig.AnimalSize / 2);
            
            var overlappingFoodCount = Physics.OverlapBoxNonAlloc(spawnPosition, halfExtents, _colliderBuffer,
                Quaternion.identity, _animalConfig.AnimalLayer);
            
            if (overlappingFoodCount <= 0)
            {
                return true;
            }
            
            foreach (var collider in _colliderBuffer)
            {
                if (collider == null) 
                    continue;

                if (collider.CompareTag(Constants.ANIMAL_TAG))
                {
                    return false;
                }
            }

            return true;
        }
        
        /// <summary>
        /// Finds and returns a random position for a food piece without overlapping other food pieces, its owner animal or the edge of the map.
        /// </summary>
        /// <returns>A new position for the food.</returns>
        public Vector3 PickRandomAnimalPosition()
        {
            var spawnPosition = Vector3.zero;
            
            for (var i = 0; i < MAX_FIND_POSITION_TRIES; ++i)
            {
                spawnPosition = new Vector3(
                    Random.Range(_minSpawnPosition.x, _maxSpawnPosition.x),
                    _animalConfig.AnimalSpawnHeight,
                    Random.Range(_minSpawnPosition.z, _maxSpawnPosition.z));

                if (CheckForNoAnimalCollisions(spawnPosition))
                {
                    break;
                }
            }

            ClearBuffer();

            return spawnPosition;
        }

        private bool CheckMinMaxPosition(Vector3 spawnPosition)
        {
            if (spawnPosition.x < _minSpawnPosition.x || spawnPosition.z < _minSpawnPosition.z ||
                spawnPosition.x > _maxSpawnPosition.x || spawnPosition.z > _maxSpawnPosition.z)
            {
                return false;
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