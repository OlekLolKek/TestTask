using System.Collections.Generic;
using Code.Data;
using Code.Factories;
using Code.Views.Game;
using UnityEngine;


namespace Code.Models
{
    public sealed class AnimalsModel
    {
        #region Properties

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