using UnityEngine;


namespace Code.Models
{
    public sealed class WorldModel
    {
        #region Properties

        public GameObject World { get; private set; }

        #endregion


        #region Methods

        public void SetWorld(GameObject world)
        {
            World = world;
        }

        #endregion
    }
}