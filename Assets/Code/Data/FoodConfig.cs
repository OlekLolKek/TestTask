using System;
using Code.Views.Game;
using UnityEngine;


namespace Code.Data
{
    [Serializable]
    public sealed class FoodConfig
    {
        [field: SerializeField] public FoodView Prefab { get; private set; }
        
        /// <summary>
        /// This is the minimum distance between the food and the animal.
        /// </summary>
        [field: Tooltip("This is the minimum distance between the food and the animal.")]
        [field: SerializeField] public float MinDistanceInUnits { get; private set; }
        
        /// <summary>
        /// This is the maximum time that an animal can spend to reach its food.
        /// </summary>
        [field: Tooltip("This is the maximum time that an animal can spend to reach its food.")]
        [field: SerializeField] public float MaxDistanceInSeconds { get; private set; }
        
        [field: SerializeField] public LayerMask FoodLayer { get; private set; }
        
        /// <summary>
        /// The approximate size of the food used to check for collisions when spawning.
        /// </summary>
        [field: Tooltip("Approximate size of the food used to check for collisions when spawning.")]
        [field: SerializeField] public float FoodSize { get; private set; }
    }
}