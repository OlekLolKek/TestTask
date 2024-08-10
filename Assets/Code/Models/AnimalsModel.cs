using System.Collections.Generic;
using Code.Data;
using Code.Factories;
using Code.Views.Game;


namespace Code.Models
{
    /// <summary>
    /// Stores and initialized the animals.
    /// </summary>
    public sealed class AnimalsModel
    {
        #region Properties

        /// <summary>
        /// Stores the views of the spawned animals.
        /// </summary>
        public HashSet<AnimalView> AnimalViews { get; } = new();

        #endregion
        
        
        #region Fields

        private readonly AnimalFactory _factory;
        private readonly GameConfig _config;

        #endregion
        

        #region CodeLife

        public AnimalsModel(GameConfig config)
        {
            _config = config;

            _factory = new AnimalFactory();
        }

        #endregion


        #region Methods

        /// <summary>
        /// Used to spawn new animals randomly according to the GameConfig.
        /// </summary>
        /// <param name="world">The animals get spawned on the specified world GameObject.</param>
        public void InitializeAnimals(WorldView world)
        {
            for (var i = 0; i < _config.AnimalCount; ++i)
            {
                var animal = _factory.Create(_config, world);

                AnimalViews.Add(animal);
            }
        }

        #endregion
    }
}