using UnityEngine;


namespace Code.Views.MainMenu
{
    public sealed class MainMenuView : BaseView
    {
        [field: SerializeField] public StartButtonsPanelView ButtonsPanel { get; private set; }
        [field: SerializeField] public NewSimulationPanelView NewSimulationPanel { get; private set; }

        private void OnEnable()
        {
            ButtonsPanel.NewSimulationButtonClick += OnNewSimulationButtonClick;
            ButtonsPanel.LoadSimulationButtonClick += OnLoadSimulationButtonClick;

            NewSimulationPanel.BackButtonClick += OnNewSimulationBackButtonClick;
        }

        private void OnDisable()
        {
            ButtonsPanel.NewSimulationButtonClick -= OnNewSimulationButtonClick;
            ButtonsPanel.LoadSimulationButtonClick -= OnLoadSimulationButtonClick;

            NewSimulationPanel.BackButtonClick -= OnNewSimulationBackButtonClick;
        }

        private void OnNewSimulationButtonClick()
        {
            ShowNewSimulationPanel();
        }

        private void OnLoadSimulationButtonClick()
        {
        }

        private void OnNewSimulationBackButtonClick()
        {
            ShowButtonsPanel();
        }

        private void ShowButtonsPanel()
        {
            ButtonsPanel.SetActive(true);
            NewSimulationPanel.SetActive(false);
        }

        private void ShowNewSimulationPanel()
        {
            ButtonsPanel.SetActive(false);
            NewSimulationPanel.SetActive(true);
        }
    }
}