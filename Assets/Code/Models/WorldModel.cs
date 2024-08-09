using System;
using UnityEngine;


namespace Code.Models
{
    public sealed class WorldModel
    {
        #region Events

        public event Action<GameObject> WorldInitialized;

        #endregion
        
        
        #region Properties

        public GameObject World { get; private set; }

        #endregion


        #region Methods

        public void SetWorld(GameObject world)
        {
            World = world;

            WorldInitialized?.Invoke(World);
        }

        #endregion
    }
}