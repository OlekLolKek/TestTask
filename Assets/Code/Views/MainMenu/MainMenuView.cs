using UnityEngine;


namespace Code.Views.MainMenu
{
    public sealed class MainMenuView : BaseView
    {
        #region Properties

        [field: SerializeField] public StartButtonsPanelView StartButtonsPanel { get; private set; }
        [field: SerializeField] public NewSimulationPanelView NewSimulationPanel { get; private set; }

        #endregion
    }
}