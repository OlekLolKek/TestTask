using Code.Interfaces;
using Code.Views.Game;


namespace Code.Controllers.Game
{
    /// <summary>
    /// The logic controller for the Food objects.
    /// </summary>
    public sealed class Food : IGetId
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
        }

        #endregion
    }
}