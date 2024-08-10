using Code.Interfaces;


namespace Code.Views.Game
{
    public sealed class FoodView : BaseView, IGetId
    {
        #region Properties

        public int ID { get; private set; }

        #endregion


        #region Methods

        public void SetId(int id)
        {
            ID = id;
        }

        #endregion
    }
}