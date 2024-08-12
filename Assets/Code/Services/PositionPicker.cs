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
    public sealed class PositionPicker : ICleanable
    {
        #region Properties

        public static PositionPicker Instance { get; private set; }

        #endregion


        #region Fields

        private readonly GameConfig _config;
        private readonly FoodConfig _foodConfig;
        private readonly WorldModel _worldModel;
        private readonly AnimalsModel _animalsModel;

        private readonly Collider[] _colliderBuffer = new Collider[3];

        private WorldView _world;
        private bool _worldInitialized;
        
        private const int MAX_FIND_POSITION_TRIES = 20;

        #endregion


        #region CodeLife

        public PositionPicker(GameConfig config, WorldModel worldModel, AnimalsModel animalsModel)
        {
            _config = config;
            _foodConfig = _config.FoodConfig;
            _worldModel = worldModel;
            _animalsModel = animalsModel;
            
            Instance = this;

            _worldModel.WorldInitialized += OnWorldInitialized;
        }

        public void Cleanup()
        {
            if (!_worldInitialized)
            {
                _worldModel.WorldInitialized -= OnWorldInitialized;
            }
        }

        #endregion


        #region Methods

        private void OnWorldInitialized(WorldView world)
        {
            _world = world;
            _worldInitialized = true;
            
            _worldModel.WorldInitialized -= OnWorldInitialized;
        }

        /// <summary>
        /// Finds and returns a random position for a food piece without overlapping other food pieces, its owner animal or the edge of the map.
        /// </summary>
        /// <returns>A new position for the food.</returns>
        public Vector3 PickRandomFoodPosition(int ownerId)
        {
            var spawnPosition = Vector3.zero;

            var worldPosition = _world != null ? _world.transform.position : Vector3.zero;
            
            var minPosition = worldPosition;
            minPosition.x -= _config.FieldSize * 0.5f;
            minPosition.z -= _config.FieldSize * 0.5f;
            
            var maxPosition = worldPosition;
            maxPosition.x += _config.FieldSize * 0.5f;
            maxPosition.z += _config.FieldSize * 0.5f;

            var ownerAnimal = _animalsModel.GetAnimalByID(ownerId);
            var animalPosition = ownerAnimal != null ? ownerAnimal.View.transform.position : Vector3.zero;
            
            for (var i = 0; i < MAX_FIND_POSITION_TRIES; ++i)
            {
                Vector3 offset = Random.insideUnitCircle;
                (offset.y, offset.z) = (offset.z, offset.y);
                
                offset *= Random.Range(_foodConfig.MinDistanceInUnits, _foodConfig.MaxDistanceInSeconds * _config.AnimalSpeed);
                
                spawnPosition = animalPosition + offset;

                if (CheckForNoCollisions(spawnPosition, minPosition, maxPosition, ownerId))
                {
                    break;
                }
            }

            ClearBuffer();

            return spawnPosition;
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