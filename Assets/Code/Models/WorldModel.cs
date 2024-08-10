using System;
using Code.Data;
using Code.Factories;
using Code.Views.Game;


namespace Code.Models
{
    /// <summary>
    /// Stores the WorldView and notifies subscribed classes when the world is created.
    /// </summary>
    public sealed class WorldModel
    {
        #region Events

        /// <summary>
        /// Called when the world is created and the value of the World property is no longer null.
        /// </summary>
        public event Action<WorldView> WorldInitialized;

        #endregion
        
        
        #region Properties

        /// <summary>
        /// The reference to the WorldView on the scene. Equals to null before the WorldInitialized event gets invoked.
        /// </summary>
        public WorldView World { get; private set; }

        #endregion


        #region Fields

        private readonly GameConfig _gameConfig;

        #endregion


        #region CodeLife

        public WorldModel(GameConfig gameConfig)
        {
            _gameConfig = gameConfig;
        }

        #endregion


        #region Methods

        /// <summary>
        /// Used to initialize the world after it's created.
        /// </summary>
        public void InitializeWorld()
        {
            var worldFactory = new WorldFactory(_gameConfig);

            World = worldFactory.Create();
            
            WorldInitialized?.Invoke(World);
        }

        #endregion
    }
}