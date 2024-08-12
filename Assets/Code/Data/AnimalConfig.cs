using System;
using Code.Views.Game;
using UnityEngine;


namespace Code.Data
{
    [Serializable]
    public sealed class AnimalConfig
    {
        [field: SerializeField] public AnimalView AnimalPrefab { get; private set; }
        [field: SerializeField] public float AnimalSpeed { get; private set; }
        [field: SerializeField] public int AnimalCount { get; private set; }
        
        /// <summary>
        /// The Y position for the animals to spawn at.
        /// </summary>
        [field: Tooltip("The Y position for the animals to spawn at.")]
        [field: SerializeField] public int AnimalSpawnHeight { get; private set; }

        /// <summary>
        /// The size of animal objects used to check for ovelaps during spawning.
        /// </summary>
        [field: Tooltip("The size of animal objects used to check for ovelaps during spawning.")]
        [field: SerializeField] public float AnimalSize { get; private set; }
        
        [field: SerializeField] public LayerMask AnimalLayer { get; private set; }

        public void SetAnimalCount(int newValue)
        {
            AnimalCount = newValue;
        }

        public void SetAnimalSpeed(float newValue)
        {
            AnimalSpeed = newValue;
        }
    }
}