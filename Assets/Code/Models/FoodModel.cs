using System.Collections.Generic;
using Code.Controllers.Game;
using Code.Data;
using Code.Factories;
using Code.Views.Game;


namespace Code.Models
{
    /// <summary>
    /// Stores and initialized food on the map.
    /// </summary>
    public sealed class FoodModel
    {
        #region Properties

        private HashSet<Food> Food { get; } = new();

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
        public void InitializeFood(HashSet<Animal> animals, WorldView worldView)
        {
            foreach (var animal in animals)
            {
                var food = _factory.Create(animal, worldView);
                Food.Add(food);
            }
        }

        #endregion
    }
}