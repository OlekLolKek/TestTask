using Code.Views.Game;
using UnityEngine;


namespace Code.Data
{
    /// <summary>
    /// Main game config that stores starting parameters, prefabs, and other configs
    /// </summary>
    [CreateAssetMenu(fileName = nameof(GameConfig), menuName = "Config/" + nameof(GameConfig), order = 0)]
    public sealed class GameConfig : ScriptableObject
    {
        #region Properties
        
        [field: Header("World settings")]
        [field: SerializeField] public WorldConfig WorldConfig { get; private set; }

        [field: Header("Animal settings")]
        [field: SerializeField] public AnimalConfig AnimalConfig { get; private set; }
        
        [field: Header("Food settings")]
        [field: SerializeField] public FoodConfig FoodConfig { get; private set; }

        [field: Header("Scene index settings")]
        [field: SerializeField] public SceneConfig SceneConfig { get; private set; }

        #endregion


        #region Methods

        /// <summary>
        /// Used to update the field size parameter in the GameConfig before switching the scenes.
        /// </summary>
        /// <param name="fieldSize">The new size value.</param>
        public void SetFieldSize(int fieldSize)
        {
            WorldConfig.SetFieldSize(Mathf.Clamp(fieldSize, Constants.MIN_FIELD_SIZE, Constants.MAX_FIELD_SIZE));
            AnimalConfig.SetAnimalCount(Mathf.Clamp(AnimalConfig.AnimalCount, Constants.MIN_ANIMAL_COUNT, GetMaxAnimalCount()));
        }

        /// <summary>
        /// Used to update the animal count parameter in the GameConfig before switching the scenes.
        /// </summary>
        /// <param name="animalCount">The new count value.</param>
        public void SetAnimalCount(int animalCount)
        {
            AnimalConfig.SetAnimalCount(
                Mathf.Clamp(animalCount, Constants.MIN_ANIMAL_COUNT, WorldConfig.FieldSize * WorldConfig.FieldSize / 2));
        }

        /// <summary>
        /// Used to update the animal speed parameter in the GameConfig before switching the scenes.
        /// </summary>
        /// <param name="animalSpeed">The new speed value.</param>
        public void SetAnimalSpeed(float animalSpeed)
        {
            AnimalConfig.SetAnimalSpeed(Mathf.Clamp(animalSpeed, Constants.MIN_ANIMAL_SPEED, Constants.MAX_ANIMAL_SPEED));
        }

        /// <summary>
        /// Calculates the maximum animal count based on the field size.
        /// </summary>
        /// <returns>The calculated max animal count.</returns>
        public int GetMaxAnimalCount()
        {
            return WorldConfig.FieldSize * WorldConfig.FieldSize / 2;
        }

        #endregion
    }
}