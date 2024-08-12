using System;
using Unity.AI.Navigation;
using UnityEngine;


namespace Code.Views.Game
{
    /// <summary>
    /// Assigned to the world prefab and GameObject in the scene.
    /// </summary>
    public sealed class WorldView : BaseView
    {
        #region Fields
        
        [SerializeField] private NavMeshSurface _navMeshSurface;

        #endregion


        #region Methods

        /// <summary>
        /// Used to bake the NavMesh surface of the world.
        /// </summary>
        public void BakeNavMesh()
        {
            _navMeshSurface.BuildNavMesh();
        }

        #endregion
    }
}