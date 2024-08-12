using Code.Interfaces;
using Code.Interfaces.MonoBehaviourCycle;
using Code.Services;
using Code.Views.Game;


namespace Code.Controllers.Game
{
    /// <summary>
    /// The logic controller for the Food objects.
    /// </summary>
    public sealed class Food : IGetId, ICleanable
    {
        #region Properties

        public FoodView View;
        public int ID { get; }

        #endregion


        #region CodeLife

        public Food(FoodView view, int id)
        {
            View = view;
            ID = id;

            View.SetParentId(this);
            View.RequestRespawn += OnRequestRespawn;
        }

        private void OnRequestRespawn()
        {
            var newPosition = PositionPicker.Instance.PickRandomFoodPosition(ID);

            View.transform.position = newPosition;
        }

        public void Cleanup()
        {
            View.RequestRespawn -= OnRequestRespawn;
        }

        #endregion
    }
}