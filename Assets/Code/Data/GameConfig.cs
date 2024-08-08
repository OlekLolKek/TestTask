using UnityEngine;


namespace Code.Data
{
    [CreateAssetMenu(fileName = nameof(GameConfig), menuName = "Config/" + nameof(GameConfig), order = 0)]
    public sealed class GameConfig : ScriptableObject
    {
        [field: SerializeField] public int FieldSize { get; private set; }
        [field: SerializeField] public int AnimalCount { get; private set; }
        [field: SerializeField] public int AnimalSpeed { get; private set; }
        
        
        public void SetValues(int fieldSize, int animalCount, int animalSpeed)
        {
            FieldSize = Mathf.Clamp(fieldSize, Constants.MIN_FIELD_SIZE, Constants.MAX_FIELD_SIZE);
            AnimalCount = Mathf.Clamp(animalCount, Constants.MIN_ANIMAL_COUNT, FieldSize * FieldSize / 2);
            AnimalSpeed = Mathf.Clamp(animalSpeed, Constants.MIN_ANIMAL_SPEED, Constants.MAX_ANIMAL_SPEED);
        }
    }
}