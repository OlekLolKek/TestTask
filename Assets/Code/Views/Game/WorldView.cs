using System;
using Unity.AI.Navigation;
using UnityEngine;


namespace Code.Views.Game
{
    public sealed class WorldView : BaseView
    {
        #region Fields
        
        [SerializeField] private NavMeshSurface _navMeshSurface;

        #endregion


        #region Methods

        public void BakeNavMesh()
        {
            _navMeshSurface.BuildNavMesh();
        }

        #endregion
    }
}