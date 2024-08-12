using Code.Controllers.Game;
using Code.Interfaces;


namespace Code.Views.Game
{
    public sealed class FoodView : BaseView, IGetId
    {
        #region Properties

        public int ID { get; private set; }

        #endregion


        #region Methods

        public void SetParentId(Food parent)
        {
            ID = parent.ID;
        }

        #endregion
    }
}