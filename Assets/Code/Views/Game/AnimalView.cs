using Code.Controllers.Game;
using Code.Interfaces;
using UnityEngine;
using UnityEngine.AI;


namespace Code.Views.Game
{
    /// <summary>
    /// Assigned to the Animal prefab and GameObjects in the scene.
    /// </summary>
    public sealed class AnimalView : BaseView, IGetId
    {
        #region Properties

        [field: SerializeField] public NavMeshAgent NavMeshAgent { get; private set; }
        public int ID { get; private set; }

        #endregion
        
        
        #region Methods

        public void SetParentId(Animal parent)
        {
            if (parent != null)
            {
                ID = parent.ID;
            }
        }

        #endregion
    }
}