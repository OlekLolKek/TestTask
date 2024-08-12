using UnityEngine;


namespace Code.Views.MainMenu
{
    /// <summary>
    /// Stores references to the main components of the main menu.
    /// </summary>
    public sealed class MainMenuView : BaseView
    {
        #region Properties

        [field: SerializeField] public StartButtonsPanelView StartButtonsPanel { get; private set; }
        [field: SerializeField] public NewSimulationPanelView NewSimulationPanel { get; private set; }

        #endregion
    }
}