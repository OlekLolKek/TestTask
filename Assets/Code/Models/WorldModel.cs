using System;
using Code.Views.Game;
using UnityEngine;


namespace Code.Models
{
    public sealed class WorldModel
    {
        #region Events

        public event Action<WorldView> WorldInitialized;

        #endregion
        
        
        #region Properties

        public WorldView World { get; private set; }

        #endregion


        #region Methods

        public void SetWorld(WorldView world)
        {
            World = world;

            WorldInitialized?.Invoke(World);
        }

        #endregion
    }
}