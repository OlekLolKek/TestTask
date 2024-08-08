using UnityEngine;


namespace Code.Views.MainMenu
{
    public sealed class MainMenuView : BaseView
    {
        [field: SerializeField] public StartButtonsPanelView ButtonsPanel { get; private set; }
        [field: SerializeField] public NewSimulationPanelView NewSimulationPanel { get; private set; }

        public void ShowButtonsPanel()
        {
            ButtonsPanel.SetActive(true);
            NewSimulationPanel.SetActive(false);
        }

        public void ShowNewSimulationPanel()
        {
            ButtonsPanel.SetActive(false);
            NewSimulationPanel.SetActive(true);
        }
    }
}