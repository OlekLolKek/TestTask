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

        public event Action<Dictionary<int, Animal>> AnimalsInitialized;

        #endregion
        
        
        #region Properties

        /// <summary>
        /// Stores the views of the spawned animals.
        /// </summary>
        public Dictionary<int, Animal> Animals = new();

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
            foreach (var animalKvp in Animals)
            {
                animalKvp.Value.Cleanup();
            }
            
            Animals.Clear();
        }

        #endregion


        #region Methods

        /// <summary>
        /// Used to spawn new animals randomly according to the GameConfig.
        /// </summary>
        public void InitializeAnimals()
        {
            for (var i = 0; i < _config.AnimalConfig.AnimalCount; ++i)
            {
                var animal = _factory.Create(_config.AnimalConfig, i);
                
                Animals.Add(i, animal);
            }

            AnimalsInitialized?.Invoke(Animals);
        }

        public Animal GetAnimalByID(int id)
        {
            return Animals.GetValueOrDefault(id);
        }

        #endregion
    }
}