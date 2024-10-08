﻿using System.Collections.Generic;
using Code.Controllers.Game;
using Code.Data;
using Code.Factories;


namespace Code.Models
{
    /// <summary>
    /// Stores and initialized food on the map.
    /// </summary>
    public sealed class FoodModel
    {
        #region Properties

        public HashSet<Food> Food { get; } = new();

        #endregion


        #region Fields

        private readonly FoodFactory _factory;

        #endregion


        #region CodeLife

        public FoodModel(GameConfig gameConfig)
        {
            _factory = new FoodFactory(gameConfig);
        }

        #endregion


        #region Methods

        /// <summary>
        /// Used to create new Food object for each existing animal.
        /// </summary>
        /// <param name="animals">The HashSet of all Animal objects in the game.</param>
        /// <param name="timeScale">The timescale at the current moment.</param>
        public void InitializeFood(Dictionary<int, Animal> animals, float timeScale)
        {
            foreach (var animalKvp in animals)
            {
                var animal = animalKvp.Value;
                var food = _factory.Create(animal, timeScale);
                animal.SetFood(food);
                Food.Add(food);
            }
        }

        #endregion
    }
}