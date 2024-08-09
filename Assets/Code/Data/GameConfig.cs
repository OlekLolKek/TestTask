using Code.Views.Game;
using UnityEngine;


namespace Code.Data
{
    [CreateAssetMenu(fileName = nameof(GameConfig), menuName = "Config/" + nameof(GameConfig), order = 0)]
    public sealed class GameConfig : ScriptableObject
    {
        #region Properties
        
        [field: Header("In-game adjustable values")]
        [field: SerializeField] public int FieldSize { get; private set; }
        [field: SerializeField] public int AnimalCount { get; private set; }
        [field: SerializeField] public int AnimalSpeed { get; private set; }

        [field: Header("Spawn settings")]
        [field: SerializeField] public AnimalView AnimalPrefab { get; private set; }
        [field: SerializeField] public int AnimalSpawnHeight { get; private set; }
        [field: SerializeField] public GameObject WorldPrefab { get; private set; }

        #endregion


        #region Methods

        public void SetFieldSize(int fieldSize)
        {
            FieldSize = Mathf.Clamp(fieldSize, Constants.MIN_FIELD_SIZE, Constants.MAX_FIELD_SIZE);
            AnimalCount = Mathf.Clamp(AnimalCount, Constants.MIN_ANIMAL_COUNT, GetMaxAnimalCount());
        }

        public void SetAnimalCount(int animalCount)
        {
            AnimalCount = Mathf.Clamp(animalCount, Constants.MIN_ANIMAL_COUNT, FieldSize * FieldSize / 2);
        }

        public void SetAnimalSpeed(int animalSpeed)
        {
            AnimalSpeed = Mathf.Clamp(animalSpeed, Constants.MIN_ANIMAL_SPEED, Constants.MAX_ANIMAL_SPEED);
        }

        public int GetMaxAnimalCount()
        {
            return FieldSize * FieldSize / 2;
        }

        #endregion
    }
}