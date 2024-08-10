using System;
using System.Collections.Generic;
using Code.Controllers.Game;
using Code.Data;
using Code.Factories;
using Code.Interfaces.MonoBehaviourCycle;
using Code.Views.Game;


namespace Code.Models
{
    /// <summary>
    /// Stores and initialized the animals.
    /// </summary>
    public sealed class AnimalsModel : ICleanable
    {
        #region Events

        public event Action<HashSet<Animal>> AnimalsInitialized;

        #endregion
        
        
        #region Properties

        /// <summary>
        /// Stores the views of the spawned animals.
        /// </summary>
        public HashSet<Animal> Animals { get; } = new();

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

        public void Cleanup()
        {
            foreach (var animal in Animals)
            {
                animal.Cleanup();
            }
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
                var animal = _factory.Create(_config, world, i);
                
                Animals.Add(animal);
            }

            AnimalsInitialized?.Invoke(Animals);
        }

        #endregion
    }
}